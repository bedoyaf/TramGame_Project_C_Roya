using UnityEngine;

public class PersonInside : MonoBehaviour
{
    public GameObject[] bubbleSprites; // Array to hold the bubble sprites for different items
    public string[] itemTypes;         // Array to hold the types of items (e.g., "Newspaper", "Burger", "Coffee", "Pills")
    public int scoreValue = 10;        // Score value gained when delivering the correct item

    private string chosenItem = "";    // The item the person wants
    private bool playerInRange = false; // Flag to indicate if the player is in range
    private bool isSatisfied = false;
    private GameCoreInside gameCoreInside;

    void Start()
    {
        // Disable all bubble sprites initially
        foreach (GameObject bubbleSprite in bubbleSprites)
        {
            bubbleSprite.SetActive(false);
        }

        // Randomly choose one item that the person wants
        chosenItem = itemTypes[Random.Range(0, itemTypes.Length)];
        ShowBubble(chosenItem);

        gameCoreInside = FindObjectOfType<GameCoreInside>();
    }

    void Update()
    {
        // Check if the player is in range and pressing the interact key ("E")
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !isSatisfied)
        {
            //Debug.Log("You pressed 'E' on me.");
            // Check if the player has the correct item in their inventory
            if (gameCoreInside.HasItem(chosenItem))
            {
                // Player has the correct item, gain score and hide the bubble
                gameCoreInside.AddScore(scoreValue);
                isSatisfied = true;
                HideBubble();
                gameCoreInside.RemoveItemText(chosenItem);
            }
        }
    }

    void ShowBubble(string item)
    {
        // Activate the bubble sprite corresponding to the chosen item
        for (int i = 0; i < itemTypes.Length; i++)
        {
            if (itemTypes[i] == item)
            {
                bubbleSprites[i].SetActive(true);
                break;
            }
        }
    }

    void HideBubble()
    {
        // Disable all bubble sprites
        foreach (GameObject bubbleSprite in bubbleSprites)
        {
            bubbleSprite.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hi.");
        // Check if the entering collider is the player
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the exiting collider is the player
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
