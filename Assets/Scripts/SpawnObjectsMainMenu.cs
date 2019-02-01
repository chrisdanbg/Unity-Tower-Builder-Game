using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsMainMenu : MonoBehaviour {

    public GameObject objectOne;
    public GameObject objectTwo;
    public GameObject objectThree;
    public GameObject objectFour;
    GameObject clone;
    GameObject[] gameObjectsToInstantiate = new GameObject[4];

    int oldRandomNumber = -1;

    // Use this for initialization
    void Start () {
        gameObjectsToInstantiate[0] = objectOne;
        gameObjectsToInstantiate[1] = objectTwo;
        gameObjectsToInstantiate[2] = objectThree;
        gameObjectsToInstantiate[3] = objectFour;
        InvokeRepeating("Spawn", 1.0f, 3);
    }
	
	// Update is called once per frame
	void Update () {

    }

    void Spawn()
    {
        Vector3 randomSpawnLocation = RandomizeSpawnLocation();

        if (!GameManager.IsGameStarted)
        {
            int randomNumber = UnityEngine.Random.Range(0, gameObjectsToInstantiate.Length);

            if (randomNumber == oldRandomNumber)
            {
                randomNumber = UnityEngine.Random.Range(0, gameObjectsToInstantiate.Length);
                Spawn();
                return;
            }

            clone = Instantiate(gameObjectsToInstantiate[randomNumber],
                                randomSpawnLocation, transform.rotation) as GameObject;
            oldRandomNumber = randomNumber;
        }

    }

    private Vector3 RandomizeSpawnLocation()
    {
        int randomX = UnityEngine.Random.Range(-19, -15);
        int randomY = UnityEngine.Random.Range(33, 34);
        int randomZ = UnityEngine.Random.Range(-15, -5);

        Vector3 randomSpawnPosition = new Vector3(randomX, randomY, randomZ);
        return randomSpawnPosition;
    }
}
