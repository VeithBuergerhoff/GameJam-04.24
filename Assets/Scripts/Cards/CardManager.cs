using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    public Card[] essences;

    public Card[] craftableCards;

    public Player player;
    public int initialEssenceAmmount = 5;

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
            CraftableCardConstants.PLANT,
            CraftableCardConstants.STEAM,
        };
        
        var basicCraftableCards = craftableCards.Where(card => basicCraftableCardNames.Contains(card.name)).ToArray();
        foreach(var card in basicCraftableCards) {
            player.cardDisplay.AddCard(card);
        }
        
    }
}
