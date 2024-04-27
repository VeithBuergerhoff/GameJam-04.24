using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public GameObject cardDisplay;

    private List<GameObject> cardDisplays = new();
    public float cardWidth;

    public void AddCard(Card card)
    {
        var image = Instantiate(cardDisplay);
        cardDisplays.Add(image);
        image.GetComponent<Image>().sprite = card.image;
        image.transform.SetParent(transform);        
        
        for (int i = 0; i < cardDisplays.Count; i++)
        {
            var width = cardWidth - cardDisplays.Count;
            var shift = width * (cardDisplays.Count - 1) / 2;
            cardDisplays[i].transform.position = transform.position + new Vector3(i * width - shift, 0, 0);
        }
    }
}