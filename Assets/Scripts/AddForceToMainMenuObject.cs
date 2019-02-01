using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceToMainMenuObject : MonoBehaviour {

    public Rigidbody rigidbody;
    Vector3 upForce = new Vector3(0, 10,0);
    bool mouseIsClicked = false;
    // Use this for initialization
    void Start () {
        rigidbody.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!mouseIsClicked)
        {
            rigidbody.AddForce(upForce * 0.5f);
            rigidbody.AddTorque((new Vector3(0,1,4)) * 0.4f * 0.4f);
        }
           
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.drag = 2;
            rigidbody.useGravity = true;
            rigidbody.drag = 0;
            mouseIsClicked = true;
            
        }
    }
}
