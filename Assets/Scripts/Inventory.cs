using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.WineBottle, amount = 0 });
        AddItem(new Item { itemType = Item.ItemType.YellowKeyCard, amount = 0 });
        AddItem(new Item { itemType = Item.ItemType.BlueKeyCard, amount = 0 });
        AddItem(new Item { itemType = Item.ItemType.ExitKeyCard, amount = 0 });
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
