using UnityEngine;

public class ChairSpawn : MonoBehaviour
{
    public GameObject[] personPrefabs; // Array to hold the prefabs of people sitting on the chair
    public float spawnChance = 0.5f;   // Probability of spawning someone on the chair (0.5 means 50% chance)

    void Start()
    {
        // Check if someone should spawn on the chair
        if (Random.value < spawnChance)
        {
            SpawnPerson();
        }
    }

    void SpawnPerson()
    {
        // Randomly select one of the person prefabs
        GameObject randomPersonPrefab = personPrefabs[Random.Range(0, personPrefabs.Length)];

        // Instantiate the selected person prefab at the chair's position and rotation
        GameObject newPerson = Instantiate(randomPersonPrefab, transform.position + new Vector3(0.285f, 0.581f, 0), transform.rotation, transform);
    }
}
