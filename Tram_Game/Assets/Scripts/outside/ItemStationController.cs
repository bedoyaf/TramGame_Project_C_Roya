using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ItemStationController : MonoBehaviour
{
    // Start is called before the first frame update
    // public Item GeneratedItem = new Item("sadam");
    public string GeneratedItem = "None";

    SpriteRenderer spriterenderer;
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    public string CreateItem()
    {
        return GeneratedItem;
    }

    public void set_Item(string item, Sprite sprite)
    {
        GeneratedItem = item;
        spriterenderer.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
