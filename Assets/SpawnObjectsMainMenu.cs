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
        InvokeRepeating("Spawn", 1.0f, 10);
    }
	
	// Update is called once per frame
	void Update () {

    }

    void Spawn()
    {
        int randomNumber = Random.Range(0, gameObjectsToInstantiate.Length);

        if (randomNumber == oldRandomNumber)
        {
            randomNumber = Random.Range(0, gameObjectsToInstantiate.Length);
            Spawn();
            return;
        }

        clone = Instantiate(gameObjectsToInstantiate[randomNumber],
                 transform.position, transform.rotation ) as GameObject;
        oldRandomNumber = randomNumber;
    }

}
