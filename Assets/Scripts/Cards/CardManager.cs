using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    public Card[] essences;

    public Card[] craftableCards;

    public Player player;
    public int initialEssenceAmmount = 5;

    public int initialCraftableCardAmmount = 10;

    private readonly static System.Random random = new();

    void Awake()
    {
        var initalEssenceNames = new string[]
        {
            EssenceConstants.FIRE,
            EssenceConstants.WATER,
            EssenceConstants.EARTH,
            EssenceConstants.AIR
        };
        var initalEssences = essences.Where(card => initalEssenceNames.Contains(card.name)).ToArray();

        for (int i = 0; i < initialEssenceAmmount; i++)
        {
            player.essences.Add(initalEssences[random.Next(initalEssences.Length)]);            
        }
        
        var basicCraftableCardNames = new string[]
        {
            CraftableCardConstants.ICE,
            CraftableCardConstants.LAVA,
            CraftableCardConstants.PLANT,
            CraftableCardConstants.STEAM,
            CraftableCardConstants.SAND,
        };
        var basicCraftableCards = craftableCards.Where(card => basicCraftableCardNames.Contains(card.name)).ToArray();
        for(int i = 0; i < initialCraftableCardAmmount; i++) {
            player.cardDisplay.AddCard(basicCraftableCards[random.Next(basicCraftableCards.Length)]);
        }
    }
}
