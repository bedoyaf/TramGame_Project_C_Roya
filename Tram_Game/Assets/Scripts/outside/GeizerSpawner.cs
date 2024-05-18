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
    public int numberOfSpawns = 4; // Number of geysers to spawn at once
    public float spawnRadius = 1f;

    void Start()
    {
        loc1 = transform.position;
        loc2 = Target.GetComponent<Transform>().position;

        parentObject = Target.GetComponent<Transform>().parent;

        StartCoroutine(SpawnGeysersRoutine());
    }

    IEnumerator SpawnGeysersRoutine()
    {
        while (true)
        {
            // Check if we should spawn based on chance
            if (!isSpawning)
            {
                isSpawning = true;

                for (int i = 0; i < numberOfSpawns; i++)
                {
                    if (Random.value < spawnChance)
                    {
                        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
                        GameObject geizerObject = Instantiate(GeizerPrefab, spawnPosition, Quaternion.identity, parentObject);

                        SpriteRenderer spriteRenderer = geizerObject.GetComponent<SpriteRenderer>();
                        if (spriteRenderer != null)
                        {
                            spriteRenderer.sortingOrder = 1;
                        }

                        OutsideGeizerController scriptComponent = geizerObject.GetComponent<OutsideGeizerController>();
                        scriptComponent.targetOB = Instantiate(Target, parentObject);
                        scriptComponent.targetOB.transform.position += Random.insideUnitSphere * spawnRadius;
                    }
                }

                for (int i = 0; i < numberOfSpawns; i++)
                {
                    if (Random.value < spawnChance)
                    {
                        Vector3 spawnPosition = loc2 + Random.insideUnitSphere * spawnRadius;
                        GameObject geizerObject = Instantiate(GeizerPrefab, spawnPosition, Quaternion.identity, parentObject);

                        SpriteRenderer spriteRenderer = geizerObject.GetComponent<SpriteRenderer>();
                        if (spriteRenderer != null)
                        {
                            spriteRenderer.sortingOrder = 1;
                        }

                        OutsideGeizerController scriptComponent = geizerObject.GetComponent<OutsideGeizerController>();
                        scriptComponent.targetOB = Instantiate(Target, parentObject);
                        scriptComponent.targetOB.transform.position = loc1;
                        scriptComponent.targetOB.transform.position += Random.insideUnitSphere * spawnRadius;
                    }
                }

                isSpawning = false;
            }

            // Wait for the specified interval before spawning again
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void Update()
    {
        // Your update logic here (if needed)
    }
}
