using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    public GameObject[] Spawnables;
    public int amount;
    public int maxWaitTime = 10;
    public int minWaitTime = 2;
    public float minOffsetSpawn = -10f;
    public float maxOffsetSpawn = 10f;
    public bool spawnInsideBounds;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            int randomWaitTime = Random.Range(minWaitTime, maxWaitTime);
            SpawnManager.Instance.SpawnSpawnable(Spawnables, amount, minOffsetSpawn, maxOffsetSpawn, spawnInsideBounds);
            yield return new WaitForSeconds(randomWaitTime);
        }
    }
}
