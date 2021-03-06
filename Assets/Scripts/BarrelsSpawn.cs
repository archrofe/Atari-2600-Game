﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelsSpawn : MonoBehaviour
{
    public GameObject[] spawnPrefabs;
    public float spawnRadius = 3f;
    public int spawnAmount = 1;
    public int currentSpawn;
    public int maxSpawn = 10;
    public int spawnInterval = 1;

    private bool hasBarreled = false;

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

    // Use this for initialization
    void Start()
    {
        currentSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBarreled && currentSpawn < maxSpawn)
        {
            StartCoroutine(Fire());
            currentSpawn++;
        }
    }

    IEnumerator Fire()
    {
        // run whatever is here first
        hasBarreled = true;

        // Spawn the barrel
        SpawnBarrels();

        yield return new WaitForSeconds(spawnInterval); // wait a few seconds

        // run whatever is here last
        hasBarreled = false;
    }

    void SpawnBarrels()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            // Spawned new GameObject
            int randomIndex = Random.Range(0, spawnPrefabs.Length);

            // Store randomly selected prefab
            GameObject randomPrefab = spawnPrefabs[randomIndex];

            // Spawned new GameObject
            GameObject clone = Instantiate(randomPrefab);

            // Calculate random position within sphere
            Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius; // calculate random position

            // Cancel out the Z
            randomPos.z = 0;

            // Set spawned object's position
            clone.transform.position = randomPos;
        }
    }
}
