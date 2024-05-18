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
    private BoxCollider2D boxCollider;  

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //SetRandomItemType();

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

       //    AdjustSpriteScaleToCollider();
    }

    void AdjustSpriteScaleToCollider()
    {
        if (spriteRenderer.sprite == null)
        {
            Debug.LogError("SpriteRenderer's sprite is not assigned.");
            return;
        }

        // Ensure the drawMode is set to Sliced to enable resizing
        spriteRenderer.drawMode = SpriteDrawMode.Sliced;

        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        // Get the size of the box collider
        Vector2 colliderSize = boxCollider.size;

        // Calculate the scale needed to match the collider's width
        Vector2 newScale = transform.localScale;

        Debug.Log(newScale);
        // Set the size of the SpriteRenderer to match the BoxCollider2D
        spriteRenderer.size = new Vector2(0.4f,0.4f);
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
