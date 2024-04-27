using Assets.Scripts;
using System;
using System.Collections.Generic;

public class Player : Entity
{
    public CardDisplay cardDisplay;

    public List<Card> cards;
    public event Action<CardController> CardClicked;

    void Awake()
    {
        cardDisplay.CardClicked += CardClicked;
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
        cardDisplay.AddCard(card);
    }

    public void RemoveCard(Card card)
    {
        cards.Remove(card);
        cardDisplay.RemoveCard(card);
    }

    void OnDestroy()
    {
        cardDisplay.CardClicked -= CardClicked;
    }
}
