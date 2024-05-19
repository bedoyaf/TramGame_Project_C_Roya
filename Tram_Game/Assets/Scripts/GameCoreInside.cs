using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCoreInside : MonoBehaviour
{
    public AudioSource spacebarSound;
    public AudioSource finsihTaskSound;

    public GameObject ItemName; // Prefab of the text object to spawn
    public RectTransform canvas;
    private List<GameObject> itemTexts = new List<GameObject>();
    public float yOffset = 30f;

    public Image fadeImage;
    public float fadeDuration = 1f;

    public TMP_FontAsset customFont;
    public TextMeshProUGUI scoreText;

    public StringListManager gatheredItems;
    PeopleManager peopleManager;

    void Start()
    {
        peopleManager = FindObjectOfType<PeopleManager>();
        gatheredItems = FindObjectOfType<StringListManager>();
        foreach (string item in gatheredItems.stringList)
        {
            SpawnItemText(item);
        }
        peopleManager.EnableAllUnsatisfiedPeople();
        UpdateScoreText();
    }

    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Start the coroutine to handle the transition
            StartCoroutine(FadeAndLoadScene());
        }
    }

    private IEnumerator FadeAndLoadScene()
    {
        // Play the spacebar sound
        spacebarSound.Play();

        // Start the fade to black
        yield return StartCoroutine(FadeToBlack());

        // Wait until the sound finishes playing
        yield return new WaitWhile(() => spacebarSound.isPlaying);

        // Load the new scene
        SceneManager.LoadScene("Outside");
    }

    private IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.color = color;
        fadeImage.gameObject.SetActive(true);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // Ensure the image is fully opaque
        color.a = 1f;
        fadeImage.color = color;
    }

    public void AddScore(int value)
    {
        finsihTaskSound.Play();
        gatheredItems.score += value;
        UpdateScoreText();
        //Debug.Log("Score: " + gatheredItems.score);
    }

    public bool HasItem(string item)
    {
       // Debug.Log(gatheredItems.Count());
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

        TextMeshProUGUI tmpComponent = newTextObject.GetComponent<TextMeshProUGUI>();
        tmpComponent.text = text;
        tmpComponent.fontSize = 15;
        tmpComponent.color = Color.black;
        tmpComponent.font = customFont; // Assign the custom font here
        tmpComponent.alignment = TextAlignmentOptions.Center; // Set text alignment to center

        RectTransform rectTransform = newTextObject.GetComponent<RectTransform>();

        // Adjust the position of the new Text GameObject
        rectTransform.pivot = new Vector2(0f, 0.9f);

        // Set anchor to top-left corner
        rectTransform.anchorMin = new Vector2(0f, 0.9f);
        rectTransform.anchorMax = new Vector2(0f, 0.9f);

        // Adjust anchored position to move down based on item count
        rectTransform.anchoredPosition -= new Vector2(0f, itemTexts.Count * yOffset);

        // Optional: Set the width of the text box (adjust as needed)
        rectTransform.sizeDelta = new Vector2(100, rectTransform.sizeDelta.y); // Set width to 200, adjust as needed

        itemTexts.Add(newTextObject);
    }

    public void RemoveItemText(string text)
    {
        for (int i = 0; i < itemTexts.Count; i++)
        {
            Debug.Log(itemTexts[i].GetComponent<TextMeshProUGUI>().text + ", " + text);
            if (itemTexts[i].GetComponent<TextMeshProUGUI>().text == text)  
            {
                GameObject itemToRemove = itemTexts[i];
                itemTexts.RemoveAt(i); // Remove from the list
                UpdateTextPositions(); // Update positions of remaining text objects
                Destroy(itemToRemove); // Destroy the corresponding GameObject
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
