using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCameraOnClick : MonoBehaviour {

    bool isGameStarted = false;

    public GameObject objectToFollow;
    public Transform objectToRotateAround;
    public Transform rotationTarget;

    Vector3 followPosition;
    Vector3 oldPosition;


    // Use this for initialization
    void Start () {
        oldPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {

        if (GameManager.IsGameStarted)
        {
            if (!isGameStarted)
            {
                transform.Rotate(45, 0, 0);
                isGameStarted = true;
            }

            followPosition = new Vector3(transform.position.x, objectToFollow.transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, followPosition, 1.0f * Time.deltaTime);
        }
        else if (GameManager.IsGameOver)
        {
            isGameStarted = false;
        }

    }


}
