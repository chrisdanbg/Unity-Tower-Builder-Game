using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform cameraTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            StartGame();
        }
	}

    void StartGame()
    {
        Vector3 beginPositionAt = new Vector3(0, 0, 0);
        cameraTransform.transform.position = Vector3.Lerp(transform.position, beginPositionAt, 5.0f * Time.deltaTime);
    }

}
