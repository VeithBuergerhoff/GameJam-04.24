using System.Linq;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public CardManager cardManager;
    public Transform cardViewport;
    public GameObject cardDisplay;

    public CardController slot1;
    public CardController slot2;
    public CardController resultSlot;

    public Player player;

    void Start()
    {
        PopulateViewport();
        slot1.CardClicked += c => { c.gameObject.SetActive(false); UpdateCraftResult(); };
        slot2.CardClicked += c => { c.gameObject.SetActive(false); UpdateCraftResult(); };
        resultSlot.CardClicked += c =>
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
            slot2.gameObject.SetActive(false);
            resultSlot.gameObject.SetActive(false);

            PopulateViewport();
            UpdateCraftResult();
        };
    }

    private void PopulateViewport()
    {
        while (cardViewport.childCount > 0)
        {
            Destroy(cardViewport.GetChild(0).gameObject);
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
                    slot1.SetCard(controller.Card);
                    slot1.gameObject.SetActive(true);
                    UpdateCraftResult();
                }
                else if (!slot2.gameObject.activeSelf)
                {
                    slot2.SetCard(controller.Card);
                    slot2.gameObject.SetActive(true);
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
}
