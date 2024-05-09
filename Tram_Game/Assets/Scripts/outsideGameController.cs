using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string itemName;
    public Item(string name)
    {
        itemName = name;
    }
}

public class outsideGameController : MonoBehaviour
{

    public List<Item> gatheredItems = new List<Item>();

    public void AddItemToStorage(Item item)
    {
        gatheredItems.Add(item);
        Debug.Log(gatheredItems.Count);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
