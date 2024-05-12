using UnityEngine;

public class ChairSpawner : MonoBehaviour
{
    public GameObject[] personSprites; // Array to hold the sprites of people sitting on the chair
    public float spawnChance = 0.5f;   // Probability of spawning someone on the chair (0.5 means 50% chance)

    void Start()
    {
        // Disable all person sprites initially
        foreach (GameObject sprite in personSprites)
        {
            sprite.SetActive(false);
        }

        // Check if someone should spawn on the chair
        if (Random.value < spawnChance)
        {
            SpawnPerson();
        }
    }

    void SpawnPerson()
    {
        // Randomly select one of the person sprites
        int randomIndex = Random.Range(0, personSprites.Length);

        // Activate the selected person sprite
        personSprites[randomIndex].SetActive(true);
    }
}