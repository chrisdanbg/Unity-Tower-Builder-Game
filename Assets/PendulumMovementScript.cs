using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumMovementScript : MonoBehaviour {


    HingeJoint hinge;
    JointMotor motor;
    Rigidbody rigidbody;

    bool isTrue = false;
	// Use this for initialization
	void Start () {
        hinge = GetComponent<HingeJoint>();

        //motor = hinge.motor;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.maxAngularVelocity = 1;
        rigidbody.angularVelocity = new Vector3(0, 0, -100);
        //Debug.Log("This time");
	}
	
	// Update is called once per frame
	void Update () {

     


	}
}
