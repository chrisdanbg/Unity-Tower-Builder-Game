using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraOnClick : MonoBehaviour {

    public GameObject objectToFollow;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, objectToFollow.transform.position , 5.0f * Time.deltaTime);
    }


}
