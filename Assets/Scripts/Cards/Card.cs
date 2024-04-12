using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardScriptableObject data;

    public SpriteRenderer spriteRenderer;
    public TMP_Text text;

    void Awake()
    {
        spriteRenderer.sprite = data.sprite;
        text.text = data.displayName;
    }
}
