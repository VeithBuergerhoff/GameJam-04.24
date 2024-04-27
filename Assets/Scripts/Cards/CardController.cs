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
    public bool isEnabled = true;

    private Image image;
    private RectTransform rectTransform;

    public Card card;
    public event Action<CardController> CardClicked;

    void Awake()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void SetHighlight()
    {
        image.color = isEnabled ? highlightColor : disabledColor;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        SetHighlight();
        if (isEnabled)
        {
            rectTransform.anchoredPosition += new Vector2(0, highlightBump);
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
        rectTransform.anchoredPosition *= Vector2.right;
    }


    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (isEnabled)
        {
            CardClicked?.Invoke(this);
            SetHighlight();
        }
    }
}
