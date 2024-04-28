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
    public CraftingManager craftingManager;

    public FloatingText hintText;

    private CardController cardToEnable;

    void Start()
    {
        player.cardDisplay.CardClicked += controller =>
        {
            if (state == GameState.PlayerTurn)
            {
                DoPlayerMove(controller);
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

    private void DoPlayerMove(CardController controller)
    {
        if (cardToEnable != null)
        {
            cardToEnable.isReady = true;
        }

        controller.isReady = false;
        cardToEnable = controller;
        var damage = (int)(enemy.CurrentEnemy.type.GetDamageMultiplier(controller.Card.damageType) * controller.Card.damage);
        enemy.TakeDamage(damage);
        PlayHint(damage);

        if (enemy.health <= 0)
        {
            state = GameState.WonFight;
            player.essences.AddRange(enemy.CurrentEnemy.drops);
            craftingManager.PopulateViewport();

            // Next Enemy
            state = GameState.PlayerTurn;
            player.Respawn();

            if (!enemy.LoadNextEnemy())
            {
                state = GameState.Won;
                SceneManager.LoadScene("WinScene");
            }
            
            ToggleCraftingView();
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
        player.TakeDamage(enemy.CurrentEnemy.damage);
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

    private void PlayHint(int damage)
    {
        if(damage == 0)
        {
            hintText.Play(enemy.healthBar.transform.position, "immune");
        }
        else
        {
            hintText.Play(enemy.healthBar.transform.position, $"-{damage}");
        }
    }
}
