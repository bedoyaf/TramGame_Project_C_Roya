using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ItemStationManagerController : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> stations = new List<GameObject>();

    public Sprite pillStand;
    public Sprite burgerStand;
    public Sprite NewspaperStand;
    public Sprite CoffeStand;

    public List<string> items = new List<string>();

    public int numOfWorkingStations = 4;
    void Start()
    {
        items.Add("Burger");
        items.Add("Pills");
        items.Add("Newspaper");
        items.Add("Coffee");
        setupStations();
    }

    void setupStations()
    {

        int setStations = 0;
        foreach (string item in items)
        {
            setStations++;
            GameObject adding = stations[UnityEngine.Random.Range(0, stations.Count)];

            stations.Remove(adding);

            Sprite setSprite = null;
            if (item == "Burger")
            {
                setSprite = burgerStand;
            }
            else if (item == "Pills")
            {
                setSprite = pillStand;
            }
            else if (item == "Newspaper")
            {
                setSprite = NewspaperStand;
            }
            else if ((item == "Coffee"))
            {
                setSprite = CoffeStand;
            }
            adding.GetComponent<ItemStationController>().set_Item(item, setSprite);

        }
        foreach(GameObject i in stations)
        {
            i.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
