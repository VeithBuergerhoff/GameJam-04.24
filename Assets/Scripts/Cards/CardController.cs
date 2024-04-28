using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CardController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color highlightColor = Color.magenta;
    public Color disabledColor = Color.gray;
    public int highlightBump = 20;
    public bool isReady = true;
    public bool isBumping = true;

    public Image image;
    public RectTransform rectTransform;

    public Card Card { get; private set; }
    public event Action<CardController> CardClicked;

    public void SetCard(Card card)
    {
        image.sprite = card.image;
        Card = card;
    }

    private void SetHighlight()
    {
        image.color = isReady ? highlightColor : disabledColor;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {

        SetHighlight();
        if (isReady && isBumping)
        {
            rectTransform.anchoredPosition += new Vector2(0, highlightBump);
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
        if (isBumping)
        {
            rectTransform.anchoredPosition *= Vector2.right;
        }
    }


    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (isReady)
        {
            CardClicked?.Invoke(this);
            SetHighlight();
        }
    }
}
