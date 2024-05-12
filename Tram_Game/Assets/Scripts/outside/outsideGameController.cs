using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

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
    public GameObject CanvasManager;

    public GameObject player;

    public float totalTime = 30f; // Total time for the timer
    private float currentTime; // Current time left
    private bool isGameOver = false; // Flag to check if game is over

    public List<string> gatheredItems = new List<string>();

    public List<GameObject> objectsToDeactivate = new List<GameObject>();
    public void AddItemToStorage(string item)
    {
        gatheredItems.Add(item);
        Debug.Log(gatheredItems.Count);
    }
    void Start()
    {
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
        PlayerPrefs.SetString("Items", JsonUtility.ToJson(gatheredItems));
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
}
