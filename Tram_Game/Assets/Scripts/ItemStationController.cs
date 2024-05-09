using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ItemStationController : MonoBehaviour
{
    // Start is called before the first frame update
    public Item GeneratedItem = new Item("sadam");
    void Start()
    {
        
    }

    public Item CreateItem()
    {
        return GeneratedItem;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
