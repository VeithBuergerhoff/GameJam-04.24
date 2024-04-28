using System.Linq;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public CardManager cardManager;
    public Transform cardViewport;
    public GameObject cardDisplay;

    public CardController slot1;
    private CardController slot1Source = null;
    public CardController slot2;
    private CardController slot2Source = null;
    public CardController resultSlot;

    public Player player;

    void Start()
    {
        PopulateViewport();
        slot1.CardClicked += c =>
        {
            c.gameObject.SetActive(false);
            if (slot1Source != null)
            {
                slot1Source.isReady = true;
            }
            slot1Source = null;
            UpdateCraftResult();
        };
        slot2.CardClicked += c =>
        {
            c.gameObject.SetActive(false);
            if (slot2Source != null)
            {
                slot2Source.isReady = true;
            }
            slot2Source = null;
            UpdateCraftResult();
        };
        resultSlot.CardClicked += c => CraftCard();
    }

    public void PopulateViewport()
    {
        foreach (Transform child in cardViewport)
        {
            Destroy(child.gameObject);
        }

        foreach (var card in player.essences)
        {
            var newCard = Instantiate(cardDisplay, cardViewport);
            var controller = newCard.GetComponent<CardController>();
            controller.SetCard(card);
            controller.isBumping = false;

            controller.CardClicked += controller =>
            {
                if (!slot1.gameObject.activeSelf)
                {
                    if (!controller.isReady)
                    {
                        return;
                    }

                    slot1.SetCard(controller.Card);
                    slot1.gameObject.SetActive(true);
                    slot1Source = controller;
                    slot1Source.isReady = false;
                    UpdateCraftResult();
                }
                else if (!slot2.gameObject.activeSelf)
                {
                    if (!controller.isReady)
                    {
                        return;
                    }

                    slot2.SetCard(controller.Card);
                    slot2.gameObject.SetActive(true);
                    slot2Source = controller;
                    slot2Source.isReady = false;
                    UpdateCraftResult();
                }
            };
        }
    }

    private void UpdateCraftResult()
    {
        if (!slot1.gameObject.activeSelf || !slot2.gameObject.activeSelf)
        {
            resultSlot.gameObject.SetActive(false);
            return;
        }

        var craftResult = new CraftingHandler(cardManager).Craft(slot1.Card.name, slot2.Card.name);
        if (craftResult == null)
        {
            resultSlot.gameObject.SetActive(false);
            return;
        }

        resultSlot.SetCard(craftResult);
        resultSlot.gameObject.SetActive(true);
    }

    private void CraftCard()
    {
        if (!slot1.gameObject.activeSelf || !slot2.gameObject.activeSelf || !resultSlot.gameObject.activeSelf)
        {
            Debug.LogWarning("We somehow clicked on a card with an invalid recipe");
            return;
        }

        var essence1 = player.essences.First(x => x.name == slot1.Card.name);
        var essence2 = player.essences.First(x => x.name == slot2.Card.name);
        player.essences.Remove(essence1);
        player.essences.Remove(essence2);
        player.cardDisplay.AddCard(resultSlot.Card);

        slot1.gameObject.SetActive(false);
        slot1Source.gameObject.SetActive(false);
        slot2.gameObject.SetActive(false);
        slot2Source.gameObject.SetActive(false);
        resultSlot.gameObject.SetActive(false);

        UpdateCraftResult();
    }
}
