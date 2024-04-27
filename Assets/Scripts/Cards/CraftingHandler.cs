using System;
using System.Linq;
using System.Collections.Generic;

public class CraftingHandler
{

    private Dictionary<(string, string), Func<Card>> craftingRecipes = new ();

    public CardManager cardManager;

    public CraftingHandler() {

        AddCardRecipe(("Wasser", "Feuer"), () => GetDampfCard());
        AddCardRecipe(("Wasser", "Luft"), () => GetEisCard());
        AddCardRecipe(("Wasser", "Erde"), () => GetPflanzeCard());        
        AddCardRecipe(("Feuer", "Erde"), () => GetLavaCard());
        AddCardRecipe(("Erde", "Luft"), () => GetSandCard());                

    }

    public Card craftFrom(string esscence1, string esscence2)
    {
        // Prüfen, ob die Kombination im Dictionary vorhanden ist
        if (craftingRecipes.ContainsKey((esscence1, esscence2)))
        {
            // Die entsprechende Karte zurückgeben, indem die Funktion im Dictionary aufgerufen wird
            return craftingRecipes[(esscence1, esscence2)]();
        }
        else
        {
            return null;
        }
    }

    private void AddCardRecipe((string, string) combination, Func<Card> cardFunction)
    {
        craftingRecipes.Add(combination, cardFunction);
        (string, string) swappedCombination = (combination.Item2, combination.Item1);
        craftingRecipes.Add(swappedCombination, cardFunction);
    }

    private Card GetSandCard()
    {
        return cardManager.craftableCards.Single(c => c.name == "Sand");
    }

    private Card GetPflanzeCard()
    {
        return cardManager.craftableCards.Single(c => c.name == "Pflanze");
    }

    private Card GetLavaCard()
    {
        return cardManager.craftableCards.Single(c => c.name == "Lava");
    }

    private Card GetDampfCard()
    {
        return cardManager.craftableCards.Single(c => c.name == "Dampf");
    }

    private Card GetEisCard()
    {
        return cardManager.craftableCards.Single(c => c.name == "Eis");
    }
}