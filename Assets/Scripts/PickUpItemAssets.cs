using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemAssets : MonoBehaviour
{
    public static PickUpItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite wineBottleSprite;
    public Sprite yellowKeyCardSprite;
    public Sprite blueKeyCardSprite;
    public Sprite exitKeyCardSprite;
}
