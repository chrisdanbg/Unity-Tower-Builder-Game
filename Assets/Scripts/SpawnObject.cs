using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{

    public GameObject cube;
    public GameObject cylinder;
    public GameObject buildingLine;
    public GameObject GameOverPanel;

    GameObject clone;
    GameObject oldClone;

    FixedJoint joint;

    private Vector3 priorFrameTransform;

    bool gameOver = false;
    bool isCloneDropped = false;

    public bool isReadyToInitiate = true;

    private float currentCubePosition;
    private float oldCubePosition;

    int score;
    public Text scoreText;
   

    // Use this for initialization
    void Start()
    {
        isCloneDropped = false;
        priorFrameTransform = transform.position;

        score = 0;

        CreateJoint();

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0) && isReadyToInitiate && !gameOver && GameManager.IsGameStarted)
        {
            isReadyToInitiate = false;
            Destroy(joint);
           
            isCloneDropped = true;
            priorFrameTransform = clone.transform.position;

            transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
            StartCoroutine(Spawn());

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
                }
                    
            }
            priorFrameTransform = clone.transform.position;
        }

        if (oldClone)
        {
            var currentposition = oldClone.transform.position.y;

            Debug.Log("Current " + currentposition);
            if (currentposition < buildingLine.transform.position.y - 1)
            {
                Debug.Log("B Lane " + buildingLine.transform.position.y);
                gameOver = true;
                GameManager.GameOver();
                GameOverPanel.SetActive(true);
            }
               
            
        }

        scoreText.text = "Score: " + score;
    }

    // 1.3 Seconds Later - When the clone is already stopped.
    void CreateJoint()
    {
        if (clone)
        {
            oldClone = clone;
            currentCubePosition = clone.transform.position.y;

            if (currentCubePosition < oldCubePosition)
            {
                gameOver = true;
                GameManager.GameOver();
                GameOverPanel.SetActive(true);
                return;
            }
            oldCubePosition = currentCubePosition;

            score++;
        }

            
        clone = Instantiate(cube, transform.position, transform.rotation);
        joint = clone.AddComponent<FixedJoint>();
        joint.connectedBody = cylinder.GetComponent<Rigidbody>();
    }

    IEnumerator Spawn()
    {
        
        yield return new WaitForSeconds(1.1f);
        CreateJoint();
        if (!gameOver)
            isReadyToInitiate = true;
    }
}
