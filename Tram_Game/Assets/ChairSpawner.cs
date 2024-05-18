using UnityEngine;

public class ChairSpawn : MonoBehaviour
{
    public GameObject[] personPrefabs; // Array to hold the prefabs of people sitting on the chair
    public float spawnChance = 0.5f;   // Probability of spawning someone on the chair (0.5 means 50% chance)
    PeopleManager peopleManager;
    public int id;

    void Start()
    {
        peopleManager = FindObjectOfType<PeopleManager>();

        if (peopleManager == null)
        {
            Debug.LogError("PeopleManager not found in the scene.");
            return;
        }

        if(peopleManager.hasId(id)) {
        }
        else if (Random.value < spawnChance)
        {
            SpawnPerson();
        }
    }

    void SpawnPerson()
    {
        // Randomly select one of the person prefabs
        GameObject randomPersonPrefab = personPrefabs[Random.Range(0, personPrefabs.Length)];

        // Instantiate the selected person prefab at the chair's position and rotation
        GameObject newPerson = Instantiate(randomPersonPrefab, transform.position + new Vector3(0.285f, 0.6f, 0), transform.rotation);
        newPerson.transform.localScale *= 2f;
        PersonInside person = newPerson.GetComponent<PersonInside>();
        person.id = id;

        peopleManager.RegisterPerson(newPerson, id);
    }

    public void DeregisterPerson(GameObject person)
    {
        peopleManager.DeregisterPerson(person,id);
    }
}
