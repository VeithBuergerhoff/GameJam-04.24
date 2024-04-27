using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public GameObject cardDisplay;
    public float cardWidth;

    public event Action<CardController> CardClicked;

    private List<CardController> cardDisplays = new();

    public void AddCard(Card card)
    {
        var image = Instantiate(cardDisplay).GetComponent<CardController>();
        cardDisplays.Add(image);
        image.GetComponent<Image>().sprite = card.image;
        image.transform.SetParent(transform);

        image.card = card;
        image.CardClicked += CardClicked;

        Rerender();
    }

    public void RemoveCard(Card card)
    {
        var item = cardDisplays.Where(x => x.card == card).FirstOrDefault();
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