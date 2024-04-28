using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public GameObject cardDisplay;
    public float cardWidth;

    // aggregates all card click events from the owned controllers 
    public event Action<CardController> CardClicked;

    private List<CardController> cardDisplays = new();

    public void AddCard(Card card)
    {
        var controller = Instantiate(cardDisplay, transform).GetComponent<CardController>();
        cardDisplays.Add(controller);

        controller.SetCard(card);
        controller.CardClicked += c => CardClicked?.Invoke(c);

        Rerender();
    }

    public void RemoveCard(Card card)
    {
        var item = cardDisplays.Where(x => x.Card == card).FirstOrDefault();
        if (item != null)
        {
            cardDisplays.Remove(item);
            item.CardClicked -= CardClicked;
            Destroy(item);
            Rerender();
        }
    }

    public void Rerender()
    {
        for (int i = 0; i < cardDisplays.Count; i++)
        {
            var width = cardWidth - cardDisplays.Count;
            var shift = width * (cardDisplays.Count - 1) / 2;
            var newPosition = transform.position + Vector3.right * (i * width - shift);
            cardDisplays[i].transform.position = newPosition;
        }
    }
}