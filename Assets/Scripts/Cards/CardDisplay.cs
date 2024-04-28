using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public GameObject cardDisplay;

    // aggregates all card click events from the owned controllers 
    public event Action<CardController> CardClicked;

    private List<CardController> cardDisplays = new();

    public void AddCard(Card card)
    {
        var controller = Instantiate(cardDisplay, transform).GetComponentInChildren<CardController>();
        cardDisplays.Add(controller);

        controller.SetCard(card);
        controller.CardClicked += c => CardClicked?.Invoke(c);
    }

    public void RemoveCard(Card card)
    {
        var item = cardDisplays.Where(x => x.Card == card).FirstOrDefault();
        if (item != null)
        {
            cardDisplays.Remove(item);
            item.CardClicked -= CardClicked;
            Destroy(item);
        }
    }
}