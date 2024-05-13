using System.Collections.Generic;
using UnityEngine;

public class GameCoreInside : MonoBehaviour
{
    public AudioSource tramSound;
    public AudioSource ambientSound;
    public AudioSource spacebarSound;

    public List<string> gatheredItems = new List<string>();
    private int score = 0;

    void Start()
    {
        //gatheredItems.Add("Newspaper");
        if (PlayerPrefs.HasKey("Items"))
        {
            string itemsJson = PlayerPrefs.GetString("Items");
            gatheredItems = JsonUtility.FromJson<List<string>>(itemsJson);
        }
        // Play the tram sound
        tramSound.Play();

        // Play the ambient sound
        ambientSound.Play();
    }

    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Play the spacebar sound
            spacebarSound.Play();
        }
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score: " + score);
    }

    public bool HasItem(string item)
    {
        Debug.Log(gatheredItems.Count);
        if (gatheredItems.Contains(item))
        {
            gatheredItems.Remove(item);
            return true;
        }
        else
        {
            //Debug.Log("Player does not have " + item);
            return false;
        }
    }
}
