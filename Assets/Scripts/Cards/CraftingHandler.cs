using System;
using System.Linq;
using System.Collections.Generic;

public class CraftingHandler
{
    private readonly Dictionary<(string, string), Func<Card>> craftingRecipes = new();

    private readonly CardManager cardManager;

    public CraftingHandler(CardManager cardManager)
    {
        this.cardManager = cardManager;
        //Basic Cards
        AddCardRecipe(EssenceConstants.WATER, EssenceConstants.FIRE, () => GetDampfCard());
        AddCardRecipe(EssenceConstants.WATER, EssenceConstants.AIR, () => GetEisCard());
        AddCardRecipe(EssenceConstants.WATER, EssenceConstants.EARTH, () => GetPflanzeCard());
        AddCardRecipe(EssenceConstants.FIRE, EssenceConstants.EARTH, () => GetLavaCard());
        AddCardRecipe(EssenceConstants.EARTH, EssenceConstants.AIR, () => GetSandCard());

        // Feuer speical
        AddCardRecipe(EssenceConstants.FIRE, EssenceConstants.SLIME, () => GetFeuerschleimCard());
        AddCardRecipe(EssenceConstants.FIRE, EssenceConstants.SHED, () => GetFeuerschuppenCard());
        AddCardRecipe(EssenceConstants.FIRE, EssenceConstants.TENTACLE, () => GetFeuertentakelCard());

        // Erde speical
        AddCardRecipe(EssenceConstants.EARTH, EssenceConstants.SLIME, () => GetErdschleimCard());
        AddCardRecipe(EssenceConstants.EARTH, EssenceConstants.SHED, () => GetErdschuppenCard());
        AddCardRecipe(EssenceConstants.EARTH, EssenceConstants.TENTACLE, () => GetErdtentakelCard());

        // Wasser special
        AddCardRecipe(EssenceConstants.WATER, EssenceConstants.SLIME, () => GetWasserschleimCard());
        AddCardRecipe(EssenceConstants.WATER, EssenceConstants.TENTACLE, () => GetWassertentakelCard());
    }

    public Card Craft(string esscence1, string esscence2)
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