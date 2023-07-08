using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    public int minOffsetSpawn = -10;
    public int maxOffsetSpawn =  10;

    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        Instance = this;
    }

    public void SpawnSpawnable(GameObject[] spawnables, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 randomSpotision3 = camera.WorldToViewportPoint(transform.position);

            randomSpotision3.x = Mathf.Clamp01(randomSpotision3.x) + Random.Range(minOffsetSpawn, maxOffsetSpawn);
            randomSpotision3.y = Mathf.Clamp01(randomSpotision3.y) + Random.Range(minOffsetSpawn, maxOffsetSpawn);

            int randomIndex = Random.Range(0, spawnables.Length);

            Instantiate(spawnables[randomIndex], randomSpotision3, Quaternion.identity);
        }
    }
}
