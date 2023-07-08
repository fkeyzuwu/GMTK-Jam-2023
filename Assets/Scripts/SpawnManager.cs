using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // An array of Spawnable gameobjects
    public GameObject[] Spawnables;
    public int maxWaitTime = 10;
    public int minWaitTime = 2;

    public int minOffsetSpawn = -10;
    public int maxOffsetSpawn =  10;
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

            // Vector3 randomSpotision3 = new Vector3(Random.Range(lowerLeftCornerMap.x, topRightCornerMap.x), Random.Range(lowerLeftCornerMap.y, topRightCornerMap.y),0f);
            Vector3 randomSpotision3 = Camera.main.WorldToViewportPoint(transform.position);

            randomSpotision3.x = Mathf.Clamp01(randomSpotision3.x) + Random.Range(minOffsetSpawn, maxOffsetSpawn);
            randomSpotision3.y = Mathf.Clamp01(randomSpotision3.y) + Random.Range(minOffsetSpawn, maxOffsetSpawn);

            

            int randomIndex = Random.Range(0, Spawnables.Length);
            
            int randomWaitTile = Random.Range(minWaitTime, maxWaitTime);
            Instantiate(Spawnables[randomIndex], randomSpotision3, Quaternion.identity);
            yield return new WaitForSeconds(randomWaitTile);
        }
        
    }
}
