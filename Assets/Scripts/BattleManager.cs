using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Player player;

    public Enemy enemy;

    public GameState state = GameState.START;


    void Awake()
    {
        player.CardClicked += controller => 
        {
            controller.isEnabled = false;
            Debug.Log("Card Clicked!");
        };
    }
}
