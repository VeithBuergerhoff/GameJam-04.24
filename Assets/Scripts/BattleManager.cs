using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Player player;

    public Enemy enemy;

    public GameState state = GameState.START;
    private CardController cardToEnable;

    void Awake()
    {
        player.CardClicked += controller =>
        {
            if (state == GameState.PLAYERTURN)
            {
                if (cardToEnable != null)
                {
                    cardToEnable.isEnabled = true;
                }
                controller.isEnabled = false;
                cardToEnable = controller;
                enemy.TakeDamage((int)(enemy.type.GetDamageMultiplier(controller.card.damageType) * controller.card.damage));

                if (enemy.health <= 0)
                {
                    state = GameState.WON;
                }
                else
                {
                    state = GameState.ENEMYTURN;
                }
            }
        };

        state = GameState.PLAYERTURN;
    }

    void Update()
    {
        if (state == GameState.ENEMYTURN)
        {
            // we can do additional checks here
            player.TakeDamage(10);
            if (player.health <= 0)
            {
                state = GameState.LOST;
            }
            else
            {
                state = GameState.PLAYERTURN;
            }
        }
    }
}
