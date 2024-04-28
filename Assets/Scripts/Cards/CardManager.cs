using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    public Card[] essences;

    public Card[] craftableCards;

    public Player player;
    public int initialCardAmmount = 5;
    private readonly static System.Random random = new();

    void Awake()
    {
        for (int i = 0; i < initialCardAmmount; i++)
        {
            var initalEssenceNames = new string[]
            {
                EssenceConstants.FIRE,
                EssenceConstants.WATER,
                EssenceConstants.EARTH,
                EssenceConstants.AIR
            };
            var initalEssences = essences.Where(card => initalEssenceNames.Contains(card.name)).ToArray();
            player.cardDisplay.AddCard(initalEssences[random.Next(initalEssences.Length)]);
        }
    }
}
