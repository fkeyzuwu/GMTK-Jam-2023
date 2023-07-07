using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // An array of Spawnable gameobjects
    public GameObject[] Spawnables;
    public int MaxWaitTime = 10;
    public int MinWaitTime = 2;
    public Vector2 topRightCornerMap;
    public Vector2 lowerLeftCornerMap;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    // Update is called once per frame

    IEnumerator SpawnObject()
    {
        // Need to create a random time wait
        while (true)
        {
            int randomIndex = Random.Range(0, Spawnables.Length);
            Vector2 randomSpotision = new Vector2(Random.Range(lowerLeftCornerMap.x, topRightCornerMap.x), Random.Range(lowerLeftCornerMap.y, topRightCornerMap.y));
            int RandomWaitTile = Random.Range(MinWaitTime, MaxWaitTime);
            Instantiate(Spawnables[randomIndex], randomSpotision, Quaternion.identity);
            yield return new WaitForSeconds(RandomWaitTile);
        }
        
    }
}
