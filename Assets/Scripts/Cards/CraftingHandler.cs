using System;
using System.Linq;
using System.Collections.Generic;

public class CraftingHandler
{

    private Dictionary<(string, string), Func<Card>> craftingRecipes = new();

    public CardManager cardManager;

    public CraftingHandler()
    {
        //Basic Cards
        AddCardRecipe("Wasser", "Feuer", () => GetDampfCard());
        AddCardRecipe("Wasser", "Luft", () => GetEisCard());
        AddCardRecipe("Wasser", "Erde", () => GetPflanzeCard());
        AddCardRecipe("Feuer", "Erde", () => GetLavaCard());
        AddCardRecipe("Erde", "Luft", () => GetSandCard());

        // Feuer speical
        AddCardRecipe("Feuer", "Schleim", () => GetFeuerschleimCard());
        AddCardRecipe("Feuer", "Schuppen", () => GetFeuerschuppenCard());
        AddCardRecipe("Feuer", "Tentakel", () => GetFeuertentakelCard());

        // Erde speical
        AddCardRecipe("Erde", "Schleim", () => GetErdschleimCard());
        AddCardRecipe("Erde", "Schuppen", () => GetErdschuppenCard());
        AddCardRecipe("Erde", "Tentakel", () => GetErdtentakelCard());

        // Wasser special
        AddCardRecipe("Wasser", "Schlein", () => GetWasserschleimCard());
        AddCardRecipe("Wasser", "Tentakel", () => GetWassertentakelCard());
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

    private void AddCardRecipe(string a, string b, Func<Card> cardFunction)
    {
        craftingRecipes.Add((a, b), cardFunction);
        craftingRecipes.Add((b, a), cardFunction);
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

    private Card GetErdschleimCard()
    {
        return cardManager.craftableCards.Single(c => c.name == "Erdschleim");
    }

    private Card GetErdschuppenCard()
    {
        return cardManager.craftableCards.Single(c => c.name == "Erdschuppen");
    }

    private Card GetErdtentakelCard()
    {
        return cardManager.craftableCards.Single(c => c.name == "Erdtentakel");
    }

    private Card GetFeuerschleimCard()
    {
        return cardManager.craftableCards.Single(c => c.name == "Feuerschleim");
    }

    private Card GetFeuerschuppenCard()
    {
        return cardManager.craftableCards.Single(c => c.name == "Feuerschuppen");
    }

    private Card GetFeuertentakelCard()
    {
        return cardManager.craftableCards.Single(c => c.name == "Feuertentakel");
    }

    private Card GetWasserschleimCard()
    {
        return cardManager.craftableCards.Single(c => c.name == "Wasserschleim");
    }

    private Card GetWassertentakelCard()
    {
        return cardManager.craftableCards.Single(c => c.name == "Wassertentakel");
    }
}