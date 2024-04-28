using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    public GameState state = GameState.Start;

    public GameObject gameView;
    public GameObject craftingView;
    public GameObject battleWinView;

    public CraftingManager craftingManager;

    public FloatingText hintText;
    public Gradient hintTextGradient;

    private CardController cardToEnable;

    void Start()
    {
        player.cardDisplay.CardClicked += controller =>
        {
            if (state == GameState.PlayerTurn)
            {
                StartCoroutine(DoPlayerMove(controller));
            }
        };

        state = GameState.PlayerTurn;
    }

    void Update()
    {
        if (state == GameState.EnemyTurn)
        {
            state = GameState.Processing;
            StartCoroutine(DoEnemyMove());
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCraftingView();
        }
    }

    public void ToggleCraftingView()
    {
        if (gameView.activeSelf)
        {
            gameView.SetActive(false);
            craftingView.SetActive(true);
        }
        else
        {
            gameView.SetActive(true);
            craftingView.SetActive(false);
        }
    }

    private IEnumerator DoPlayerMove(CardController controller)
    {
        if (cardToEnable != null)
        {
            cardToEnable.isReady = true;
        }

        controller.isReady = false;
        cardToEnable = controller;
        var damageMultiplier = enemy.CurrentEnemy.type.GetDamageMultiplier(controller.Card.damageType);
        var damage = (int)(damageMultiplier * controller.Card.damage);
        enemy.TakeDamage(damage);
        if (damage == 0)
        {
            hintText.Play(new Vector2(200, 180), "immune", Color.gray);
        }
        else
        {
            hintText.Play(new Vector2(200, 180), $"-{damage}", hintTextGradient.Evaluate(damageMultiplier / 2));
        }

        if (enemy.health <= 0)
        {
            state = GameState.WonFight;
            player.essences.AddRange(enemy.CurrentEnemy.drops);
            craftingManager.PopulateViewport();

            // Next Enemy
            state = GameState.PlayerTurn;
            player.Respawn();

            gameView.SetActive(false);
            battleWinView.SetActive(true);
            yield return new WaitForSeconds(2);
            battleWinView.SetActive(false);

            if (!enemy.LoadNextEnemy())
            {
                state = GameState.Won;
                SceneManager.LoadScene("WinScene");
            }

            craftingView.SetActive(true);
        }
        else
        {
            state = GameState.EnemyTurn;
        }
    }

    private IEnumerator DoEnemyMove()
    {
        yield return new WaitForSeconds(1);
        // we can do additional checks here
        var damage = enemy.CurrentEnemy.damage;
        hintText.Play(new Vector2(-200, 180), $"-{damage}", Color.red);
        player.TakeDamage(damage);
        if (player.health <= 0)
        {
            state = GameState.Lost;
            SceneManager.LoadScene("LoseScene");
        }
        else
        {
            state = GameState.PlayerTurn;
        }
    }
}
