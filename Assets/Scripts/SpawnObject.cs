using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    public GameObject cube;
    public GameObject cylinder;
    GameObject clone;
    Rigidbody cloneRigid;
    private Vector3 priorFrameTransform;

    FixedJoint joint;

    bool isCloneDropped = false;
    public bool isReadyToInitiate = true;
    // Use this for initialization
    void Start()
    {
        isCloneDropped = false;
        priorFrameTransform = transform.position;


        CreateJoint();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isReadyToInitiate)
        {
            isReadyToInitiate = false;
            Destroy(joint);
           
            isCloneDropped = true;
            priorFrameTransform = clone.transform.position;

            transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
            StartCoroutine(Example());
        }


        if (clone)
        {
            
            if (Vector3.Distance(clone.transform.position, priorFrameTransform) > 0.01f)
            {
                isCloneDropped = true;

            }
            else
            {
                if (isCloneDropped)
                {
                    isCloneDropped = false;
                    Debug.Log(isCloneDropped);
                }
                    
            }
            priorFrameTransform = clone.transform.position;
        }

    }


    void CreateJoint()
    {
        clone = Instantiate(cube, transform.position, transform.rotation);
        joint = clone.AddComponent<FixedJoint>();
        joint.connectedBody = cylinder.GetComponent<Rigidbody>();
    }

    IEnumerator Example()
    {
        
        yield return new WaitForSeconds(1);
        CreateJoint();
        isReadyToInitiate = true;
    }
}
