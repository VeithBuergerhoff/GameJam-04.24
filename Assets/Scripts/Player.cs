using Assets.Scripts;
using System;

public class Player : Entity
{
    public CardDisplay cardDisplay;

    public event Action<CardController> CardClicked;

    void Awake()
    {
        cardDisplay.CardClicked += CardClicked;
        Respawn();
    }

    public void AddCard(Card card)
    {
        cardDisplay.AddCard(card);
    }

    public void RemoveCard(Card card)
    {
        cardDisplay.RemoveCard(card);
    }

    void OnDestroy()
    {
        cardDisplay.CardClicked -= CardClicked;
    }
}
