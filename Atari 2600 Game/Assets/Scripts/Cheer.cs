using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cheer : MonoBehaviour
{

    public GameObject[] spawnPrefabs;
    public float spawnRadius = 1f;
    public int spawnAmount = 1;

    public int currentSpawn;
    public int maxSpawn = 10;
    public int spawnInterval = 1;
    private bool hasSpawned = false;

    public float force = 20f; // force to move spawned object

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
        if (!hasSpawned && currentSpawn < maxSpawn)
        {

            StartCoroutine(Fire());
            currentSpawn++;
        }
    }

    IEnumerator Fire() // running the spawner on a timer
    {
        // run whatever is here first
        hasSpawned = true;

        // Spawn the bullet
        Spawn();
        
        yield return new WaitForSeconds(spawnInterval); // wait a few seconds

        // run whatever is here last
        hasSpawned = false;
    }

    void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            // Spawned new GameObject
            int randomIndex = Random.Range(0, spawnPrefabs.Length);

            // Store randomly selected prefab
            GameObject randomPrefab = spawnPrefabs[randomIndex];

            // Spawned new GameObject
            GameObject clone = Instantiate(randomPrefab);

            // Grab MeshRenderer
            MeshRenderer rend = clone.GetComponent<MeshRenderer>();

            // Change the Colour
            float r = Random.Range(0, 2); // first number is Inclusive, second number is Exclusive.
            float g = Random.Range(0, 2);
            float b = Random.Range(0, 2);
            float a = 1;
            rend.material.color = new Color(r, g, b, a);

            // Calculate random position within sphere
            Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius; // calculate random position

            // Cancel out the Z
            randomPos.z = 0;

            // Set spawned object's position
            clone.transform.position = randomPos;

            // Apply force to RigidBody
            Rigidbody2D rigid2D = clone.GetComponent<Rigidbody2D>();
            rigid2D.AddForce(-transform.up * force); // add force to move Cube down
        }
        
    }
}
