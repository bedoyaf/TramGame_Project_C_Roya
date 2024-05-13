using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCoreInside : MonoBehaviour
{
    public AudioSource tramSound;
    public AudioSource ambientSound;
    public AudioSource spacebarSound;

    public GameObject ItemName; // Prefab of the text object to spawn
    public RectTransform canvas;
    public List<GameObject> itemTexts = new List<GameObject>();
    public float yOffset = 30f;

    public TextMeshProUGUI scoreText;

    public StringListManager gatheredItems;

    void Start()
    {
        gatheredItems = FindObjectOfType<StringListManager>();
        foreach (string item in gatheredItems.stringList)
        {
            SpawnItemText(item);
        }
        // Play the tram sound
        tramSound.Play();

        // Play the ambient sound
        ambientSound.Play();

        UpdateScoreText();
    }

    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Play the spacebar sound
            spacebarSound.Play();
            SceneManager.LoadScene("Outside");
        }
    }

    public void AddScore(int value)
    {
        gatheredItems.score += value;
        UpdateScoreText();
        Debug.Log("Score: " + gatheredItems.score);
    }

    public bool HasItem(string item)
    {
        Debug.Log(gatheredItems.Count());
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

    void UpdateScoreText()
    {
        // Update the score text with the current score value
        scoreText.text = "Score: " + gatheredItems.score;
    }

    public void SpawnItemText(string text)
    {
        GameObject newTextObject = Instantiate(ItemName, canvas);

        newTextObject.GetComponent<TextMeshProUGUI>().text = text;
        newTextObject.GetComponent<TextMeshProUGUI>().fontSize = 15;
        newTextObject.GetComponent<TextMeshProUGUI>().color = Color.black;

        RectTransform rectTransform = newTextObject.GetComponent<RectTransform>();

        // Adjust the position of the new Text GameObject
        rectTransform.pivot = new Vector2(0.05f, 0.9f);

        // Set anchor to top-left corner
        rectTransform.anchorMin = new Vector2(0.05f, 0.85f);
        rectTransform.anchorMax = new Vector2(0.05f, 0.85f);

        // Adjust anchored position to move down based on item count
        rectTransform.anchoredPosition -= new Vector2(0f, itemTexts.Count * yOffset);
        itemTexts.Add(newTextObject);
    }

    public void RemoveItemText(string text)
    {
        for (int i = 0; i < itemTexts.Count; i++)
        {
            if (itemTexts[i].GetComponent<TextMeshProUGUI>().text == text)
            {
                Destroy(itemTexts[i]); // Destroy the corresponding GameObject
                itemTexts.RemoveAt(i); // Remove from the list
                UpdateTextPositions(); // Update positions of remaining text objects
                break;
            }
        }
    }

    void UpdateTextPositions()
    {
        // Adjust anchored positions of remaining text objects
        for (int i = 0; i < itemTexts.Count; i++)
        {
            RectTransform rectTransform = itemTexts[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0f, -i * yOffset);
        }
    }
}
