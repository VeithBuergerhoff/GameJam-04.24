using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public Card[] cards;
    public CardDisplay cardDisplay;
    private readonly static System.Random random= new();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cardDisplay.AddCard(cards[random.Next(cards.Length)]);
        }
    }
}
