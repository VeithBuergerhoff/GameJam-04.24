using UnityEngine;

public class CardManager : MonoBehaviour
{
    public Card[] cards;
    public Player player;
    public int initialCardAmmount = 5;
    private readonly static System.Random random = new();

    void Awake()
    {
        for (int i = 0; i < initialCardAmmount; i++)
        {
            player.cardDisplay.AddCard(cards[random.Next(cards.Length)]);
        }
    }
}
