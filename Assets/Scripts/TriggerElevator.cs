using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerElevator : MonoBehaviour {

    int counter = 0;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (counter > 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
            }
            counter++;
        }
	}
}
