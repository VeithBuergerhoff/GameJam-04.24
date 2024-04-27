using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CardController : EventTrigger
{
    public Color highlightColor = Color.magenta;
    public int highlightBump = 20;

    private Image image;
    private RectTransform rectTransform;

    public Card card;
    public event Action<Card> CardClicked;

    void Awake()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        image.color = highlightColor;
        rectTransform.anchoredPosition += new Vector2(0, highlightBump);
    }

    override public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
        rectTransform.anchoredPosition *= Vector2.right;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        CardClicked?.Invoke(card);
    }
}
