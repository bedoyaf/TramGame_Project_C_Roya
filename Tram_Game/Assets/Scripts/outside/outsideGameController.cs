using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
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
   // public GameObject NonDeletedSuperObject;
    public GameObject CanvasManager;

    public GameObject player;

    public float totalTime = 30f; // Total time for the timer
    private float currentTime; // Current time left
    private bool isGameOver = false; // Flag to check if game is over

    public StringListManager gatheredItems;
    PeopleManager peopleManager;

    public List<GameObject> objectsToDeactivate = new List<GameObject>();
    public void AddItemToStorage(string item)
    {
        gatheredItems.Add(item);
    }

    void Start()
    {
        gatheredItems = FindObjectOfType<StringListManager>();
        peopleManager = FindObjectOfType<PeopleManager>();
        peopleManager.DisableAllUnsatisfiedPeople();

        if (gatheredItems == null)
        {
            GameObject managerObj = new GameObject("StringListManager");
            gatheredItems = managerObj.AddComponent<StringListManager>();
        }
        StartTimer();
    }
    void StartTimer()
    {
        currentTime = totalTime;
    }


    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            // Update the current time
            currentTime -= Time.deltaTime;
            CanvasManager.GetComponent<outsideChangeUItext>().ShowTime(Mathf.Round(currentTime).ToString());

            // Check if time is up
            if (currentTime <= 0)
            {
                Debug.Log("times up");
                // Set game over flag to true
                isGameOver = true;

                // Call game over function or show game over screen
                bool isintram = player.GetComponent<outsidePlayerController>().is_on_dropping_station();
                if (isintram)
                {
                    end_scene();
                }
                else
                {
                    GameOver();
                }
            }
        }
    }
    public void end_scene()
    {
        List<string> items = player.GetComponent<outsidePlayerController>().get_player_inventory();
        foreach(string i in items)
        {
            AddItemToStorage(i);
        }
        //Debug.Log("Gathered count" + gatheredItems.Count());
        SceneManager.LoadScene("Inside");
    }

    void GameOver()
    {
        CanvasManager.GetComponent<outsideChangeUItext>().ShowGameOver();
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
    }


    public void Restart()//add any other reset
    {
        Debug.Log("restarting");
        gatheredItems.Clear();
      //  NonDeletedSuperObject.GetComponent<StringListManager>().ClearList();
        SceneManager.LoadScene("Inside");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
