using Assets.Scripts;
using System.Collections.Generic;

public class Player : Entity
{
    public CardDisplay cardDisplay;

    public List<Card> cards;

    void Awake()
    {
        cardDisplay.CardClicked += card => {
            RemoveCard(card);
        };
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
}
