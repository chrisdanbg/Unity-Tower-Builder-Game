using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraOnClick : MonoBehaviour {

    // leftPosition.position = new Vector3(-22.4f, 19, -11.7f);
    // rightPosition.position = new Vector3(-13.4f, 19, -11.7f);

    public GameObject objectToFollow;
    public Transform objectToRotateAround;

    Vector3 followPosition;
    Vector3 oldPosition;

    bool leftCamera = false;
    bool rightCamera = false;

	// Use this for initialization
	void Start () {
       
      
	}

    // Update is called once per frame
    void Update()
    {
        followPosition = new Vector3(transform.position.x, objectToFollow.transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, followPosition, 5.0f * Time.deltaTime);

        CheckForRotation();
    }


    void CheckForRotation()
    {
        if (SwipeInput.swipedLeft && leftCamera == false && rightCamera == false)
        {
            oldPosition = transform.position;
            transform.position = new Vector3(-22.4f, 19, -11.7f);
            transform.Rotate(0, +90, 0);
            leftCamera = true;
        }

        if (rightCamera == false && SwipeInput.swipedRight && leftCamera == false)
        {
            oldPosition = transform.position;
            transform.position = new Vector3(-17.3f, 19, -6.9f);
            transform.Rotate(0, -180, 0);
            rightCamera = true;
        }

        if (leftCamera == true && SwipeInput.swipedRight && rightCamera == false)
        {
            transform.position = oldPosition;
            transform.Rotate(0, -90, 0);
            leftCamera = false;
        }

        if (rightCamera == true && SwipeInput.swipedLeft && leftCamera == false)
        {
            transform.position = oldPosition;
            transform.Rotate(0, +180, 0);
            rightCamera = false;
        }
    }
}
