using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    public GameObject[] Spawnables;
    public int amount;
    public int maxWaitTime = 10;
    public int minWaitTime = 2;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            int randomWaitTime = Random.Range(minWaitTime, maxWaitTime);
            SpawnManager.Instance.SpawnSpawnable(Spawnables, 1);
            yield return new WaitForSeconds(randomWaitTime);
        }
    }
}
