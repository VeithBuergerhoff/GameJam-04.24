using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

public class BattleManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    public GameState state = GameState.Start;

    public GameObject gameView;
    public GameObject craftingView;
    public CraftingManager craftingManager;

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

    private void ToggleCraftingView()
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
        enemy.TakeDamage((int)(enemy.CurrentEnemy.type.GetDamageMultiplier(controller.Card.damageType) * controller.Card.damage));

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
}
