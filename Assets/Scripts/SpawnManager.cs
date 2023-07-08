using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    

    #region Singleton
    public static SpawnManager Instance { get; private set; }
    Camera camera;
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

    public int minOffsetSpawn = -10;
    public int maxOffsetSpawn =  10;

   
    // Start is called before the first frame update
    void Start()
    {
        

    }

    public void SpawnSpawnable(GameObject[] spawnables, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 randomSpotision3 = camera.WorldToViewportPoint(transform.position);

            randomSpotision3.x = Mathf.Clamp01(randomSpotision3.x) + Random.Range(minOffsetSpawn, maxOffsetSpawn);
            randomSpotision3.y = Mathf.Clamp01(randomSpotision3.y) + Random.Range(minOffsetSpawn, maxOffsetSpawn);


            Instantiate(spawnables[Random.Range(0, spawnables.Length)], randomSpotision3, Quaternion.identity);
        }
    }
}
