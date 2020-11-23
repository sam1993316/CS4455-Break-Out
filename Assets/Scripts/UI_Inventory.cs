using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private List<RectTransform> itemSlots;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        itemSlots = new List<RectTransform>();
    }

    public void SetInvetory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 60f;
        foreach(Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x, y * -itemSlotCellSize);

            Image image = itemSlotRectTransform.Find("item").GetComponent<Image>();
            image.sprite = item.GetSprite();
            Text uiText = itemSlotRectTransform.Find("text").GetComponent<Text>();
            uiText.text = item.amount.ToString();


            if (item.itemType == Item.ItemType.YellowKeyCard)
            {
                image.color = UnityEngine.Color.yellow;
            }
            else if (item.itemType == Item.ItemType.BlueKeyCard)
            {
                image.color = UnityEngine.Color.blue;
            }
            else if (item.itemType == Item.ItemType.ExitKeyCard)
            {
                image.color = UnityEngine.Color.grey;
            }
            y++;
            itemSlots.Add(itemSlotRectTransform);
        }
    }

    public void IncrementWineBottleAmount()
    {
        inventory.GetItemList()[0].amount++;
        Text uiText = itemSlots[0].Find("text").GetComponent<Text>();
        uiText.text = inventory.GetItemList()[0].amount.ToString();
    }

    public void DecrementWineBottleAmount()
    {
        inventory.GetItemList()[0].amount--;
        Text uiText = itemSlots[0].Find("text").GetComponent<Text>();
        uiText.text = inventory.GetItemList()[0].amount.ToString();
    }



    public void IncrementKeyCardAmount(string keyID)
    {
        Debug.Log("Incrementing amount...");

        if (keyID.Equals("yellow"))
        {
            inventory.GetItemList()[1].amount++;
            Text uiText = itemSlots[1].Find("text").GetComponent<Text>();
            uiText.text = inventory.GetItemList()[1].amount.ToString();
        }
        else if (keyID.Equals("blue"))
        {
            inventory.GetItemList()[2].amount++;
            Text uiText = itemSlots[2].Find("text").GetComponent<Text>();
            uiText.text = inventory.GetItemList()[2].amount.ToString();
        }
        else if (keyID.Equals("Exit") || keyID.Equals("Tutorial"))
        {
            inventory.GetItemList()[3].amount++;
            Text uiText = itemSlots[3].Find("text").GetComponent<Text>();
            uiText.text = inventory.GetItemList()[3].amount.ToString();
        }

    }
}
