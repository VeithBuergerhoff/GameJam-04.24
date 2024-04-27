using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public GameObject cardDisplay;

    private List<Tuple<Card, GameObject>> cardDisplays = new();
    public float cardWidth;

    public event Action<Card> CardClicked;

    public void AddCard(Card card)
    {
        var image = Instantiate(cardDisplay);
        cardDisplays.Add(Tuple.Create(card, image));
        image.GetComponent<Image>().sprite = card.image;
        var cardController = image.GetComponent<CardController>();
        image.transform.SetParent(transform);

        cardController.card = card;
        cardController.CardClicked += CardClicked;

        Rerender();
    }

    public void RemoveCard(Card card)
    {
        var item = cardDisplays.Where(x => x.Item1 == card).FirstOrDefault();
        if (item != null)
        {
            cardDisplays.Remove(item);
            Destroy(item.Item2);
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
            cardDisplays[i].Item2.transform.position = newPosition;
        }
    }
}