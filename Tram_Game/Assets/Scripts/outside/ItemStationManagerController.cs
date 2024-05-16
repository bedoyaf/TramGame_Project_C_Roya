using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ItemStationManagerController : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> stations = new List<GameObject>();

    public List<string> items = new List<string>();

    public int numOfWorkingStations = 4;
    void Start()
    {
        items.Add("Burger");
        items.Add("Pills");
        items.Add("Newspaper");
        items.Add("Coffee");
       // setupStations();
    }

    void setupStations()
    {
      //  Debug.Log("setting up");
        int setStations = 0;
        foreach (string item in items)
        {
            setStations++;
            if(stations.Count == 0)
            {
                break;
            }
            int randomIndex = UnityEngine.Random.Range(0, stations.Count);
            GameObject adding = stations[randomIndex];

            adding.GetComponent<ItemStationController>().SetItem(item);

            stations.RemoveAt(randomIndex);

        }
        foreach(GameObject i in stations)
        {
            i.SetActive(false);
        }
    }


    void Update()
    {

    }
}
