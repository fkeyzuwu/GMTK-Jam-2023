using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RandomMultipleRange;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{

    #region Singleton
    public static SpawnManager Instance { get; private set; }
    private new Camera camera;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            camera = Camera.main;
        }
    }
    #endregion
    
    public void SpawnSpawnable(GameObject[] spawnables, int amount, float minOffsetSpawn, float maxOffsetSpawn, bool insideBounds)
    {
        for (int i = 0; i < amount; i++)
        {
            if (insideBounds)
                SpawnInbound(spawnables, minOffsetSpawn, maxOffsetSpawn);
            else
                SpawnOutbound(spawnables, minOffsetSpawn,maxOffsetSpawn);
        }
    }

    private void SpawnInbound(GameObject[] spawnables, float minOffsetSpawn, float maxOffsetSpawn)
    {
        float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y) + Random.Range(minOffsetSpawn, maxOffsetSpawn);
        float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x) + Random.Range(minOffsetSpawn, maxOffsetSpawn);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        Instantiate(spawnables[Random.Range(0, spawnables.Length)], spawnPosition, Quaternion.identity);
    }

    private void SpawnOutbound(GameObject[] spawnables, float minOffsetSpawn, float maxOffsetSpawn)
    {
        float spawnPointInsideBounds = RandomValueFromRanges(
                new RandomMultipleRange.Range(-0.1f - Random.Range(minOffsetSpawn, maxOffsetSpawn), 1.1f + Random.Range(minOffsetSpawn, maxOffsetSpawn)));
        float spawnPointOutsideBounds = RandomValueFromRanges(
            new RandomMultipleRange.Range(1.1f, 1.1f + Random.Range(minOffsetSpawn, maxOffsetSpawn)),
            new RandomMultipleRange.Range(-0.1f - Random.Range(minOffsetSpawn, maxOffsetSpawn), -0.1f));

        Vector3 outOfBoundsVector;
        int randomBool = Random.Range(0, 2);
        if (randomBool == 0)
        {
            outOfBoundsVector = Camera.main.ViewportToWorldPoint(new Vector3(spawnPointInsideBounds, spawnPointOutsideBounds, 10.0f));
        }
        else
        {
            outOfBoundsVector = Camera.main.ViewportToWorldPoint(new Vector3(spawnPointOutsideBounds, spawnPointInsideBounds, 10.0f));
        }

        Instantiate(spawnables[Random.Range(0, spawnables.Length)], outOfBoundsVector, Quaternion.identity);
    }
}
