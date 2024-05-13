using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStationController : MonoBehaviour
{
    public Sprite pillStand;
    public Sprite burgerStand;
    public Sprite newspaperStand;
    public Sprite coffeeStand;

    private string[] itemTypes = { "Burger", "Pills", "Newspaper", "Coffee" };

    public string GeneratedItem { get; private set; } = "None";

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetRandomItemType();
    }

    void SetRandomItemType()
    {
        int randomIndex = Random.Range(0, itemTypes.Length);
        GeneratedItem = itemTypes[randomIndex];
        SetSpriteForItemType(GeneratedItem);
    }

    void SetSpriteForItemType(string itemType)
    {
        switch (itemType)
        {
            case "Burger":
                spriteRenderer.sprite = burgerStand;
                break;
            case "Pills":
                spriteRenderer.sprite = pillStand;
                break;
            case "Newspaper":
                spriteRenderer.sprite = newspaperStand;
                break;
            case "Coffee":
                spriteRenderer.sprite = coffeeStand;
                break;
            default:
                Debug.LogError("Invalid item type: " + itemType);
                break;
        }
    }

    public void SetItem(string item)
    {
        GeneratedItem = item;
        SetSpriteForItemType(item);
    }

    public string CreateItem()
    {
        return GeneratedItem;
    }
}
