using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class outsideChangeUItext : MonoBehaviour
{
    public Canvas canvas;
    public GameObject ItemName;

    TextMeshProUGUI itemtext;

    public GameObject GameOver;

    public TextMeshProUGUI timeText;

    List<GameObject> itemTexts = new List<GameObject>();

    public float yOffset = 10f;

    void Start()
    {
        
    }
    public void ShowTime(string tim)
    {
        timeText.text = tim;
    }
    public void SpawnItemText(string text)
    {

        GameObject newTextObject = Instantiate(ItemName, canvas.transform);

        newTextObject.GetComponent<TextMeshProUGUI>().text = text;
        newTextObject.GetComponent<TextMeshProUGUI>().fontSize = 15;

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

    public void DeleteItemTexts()
    {
        for(int i = 0; i < itemTexts.Count; i++)
        {
            Destroy(itemTexts[i]);
        }
        itemTexts.Clear();
    }
    public void ShowGameOver()
    {

        GameOver.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
