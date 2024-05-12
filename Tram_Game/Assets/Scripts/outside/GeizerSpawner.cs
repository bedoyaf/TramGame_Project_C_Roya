using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeizerSpawner : MonoBehaviour
{
    public GameObject Target;
    public GameObject GeizerPrefab;
    Vector3 loc1;
    Vector3 loc2;

    bool isSpawning = false;

    public Transform parentObject;

    public float spawnInterval = 5f; // Interval between spawns
    public float spawnChance = 0.9f; // Chance of spawning
    public int numberOfSpawns = 4; // Number of scripts to spawn at once
    public float spawnRadius = 1f;
    // Start is called before the first frame update
    void Start()
    {
        loc1 = transform.position;
        loc2 = Target.GetComponent<Transform>().position;

        parentObject = Target.GetComponent<Transform>().parent;

        StartCoroutine(SpawnScriptsRoutine());
    }

    IEnumerator SpawnScriptsRoutine()
    {
        while (true)
        {
            // Check if we should spawn based on chance
            if (!isSpawning)
            {
                isSpawning = true;
                // Instantiate the script prefab

                for (int i = 0; i < numberOfSpawns; i++)
                {
                    if (Random.value < spawnChance)
                    {
                        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
                        GameObject scriptObject = Instantiate(GeizerPrefab, spawnPosition, Quaternion.identity, parentObject);

                        OutsideGeizerController scriptComponent = scriptObject.GetComponent<OutsideGeizerController>(); // Replace YourScriptComponent with the actual name of your script component
                                                                                                                        // Set up the script with loc1 as character location and Target as the target object
                                                                                                                        //   scriptComponent.transform.position = loc1;
                        scriptComponent.targetOB = Instantiate(Target, parentObject);
                        scriptComponent.targetOB.transform.position += Random.insideUnitSphere * spawnRadius;
                    }
                    // Calculate random position within the spawn radius

                }
                for (int i = 0; i < numberOfSpawns; i++)
                {
                    if (Random.value < spawnChance)
                    {
                        Vector3 spawnPosition = loc2 + Random.insideUnitSphere * spawnRadius;
                        GameObject scriptObject = Instantiate(GeizerPrefab, spawnPosition, Quaternion.identity, parentObject);

                        OutsideGeizerController scriptComponent = scriptObject.GetComponent<OutsideGeizerController>(); // Replace YourScriptComponent with the actual name of your script component
                                                                                                                        // Set up the script with loc1 as character location and Target as the target object
                                                                                                                        //   scriptComponent.transform.position = loc1;
                        scriptComponent.targetOB = Instantiate(Target, parentObject);
                        scriptComponent.targetOB.transform.position = loc1;
                        scriptComponent.targetOB.transform.position += Random.insideUnitSphere * spawnRadius;
                    }
                    // Calculate random position within the spawn radius

                }


                isSpawning = false;
            }

            // Wait for the specified interval before spawning again
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
