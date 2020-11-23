using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        WineBottle,
        YellowKeyCard,
        BlueKeyCard,
        ExitKeyCard
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.WineBottle: return PickUpItemAssets.Instance.wineBottleSprite;
            case ItemType.YellowKeyCard: return PickUpItemAssets.Instance.yellowKeyCardSprite;
            case ItemType.BlueKeyCard: return PickUpItemAssets.Instance.blueKeyCardSprite;
            case ItemType.ExitKeyCard: return PickUpItemAssets.Instance.exitKeyCardSprite;
        }
    }
}
