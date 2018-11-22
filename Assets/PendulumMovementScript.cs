using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumMovementScript : MonoBehaviour {


    HingeJoint hinge;
    JointMotor motor;
    Rigidbody rigidbody;

    public GameObject gameObject;

    bool started = false;
	// Use this for initialization
	void Start () {
        hinge = gameObject.GetComponent<HingeJoint>();

        var motor = hinge.motor;
        motor.targetVelocity = 5;
        motor.force = 5;
        hinge.motor = motor;
        hinge.useMotor = true;
        rigidbody = gameObject.GetComponent<Rigidbody>();
       
	}
	
	// Update is called once per frame
	void Update () {
 
        if (!started)
        {
            StartCoroutine(HandleIt());
            started = true;
        }

	}

    private IEnumerator HandleIt()
    {
        yield return new WaitForSeconds(2.0f);
        motor.force = 0;
        hinge.motor = motor;
    }
}
