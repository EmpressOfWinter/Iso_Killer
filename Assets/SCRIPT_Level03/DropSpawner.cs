using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    public Transform[] dropPoints;

    public GameObject cookiePrefab;
    public GameObject bombPrefab;

    private float timeToSpawn = 2f; //sec after the game start the drop spawn
    public float timeBetweenWaves = 1f; //spawn rates

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            SpawnDrop();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
        


    }

    void SpawnDrop()
    {

        int randomIndex = Random.Range(0, dropPoints.Length);

        for (int i = 0; i < dropPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(cookiePrefab, dropPoints[i].position, Quaternion.Euler(-90, 0, 0));
            }
            else
            {
                Instantiate(bombPrefab, dropPoints[i].position, Quaternion.identity);
            }
        }
    }
}
