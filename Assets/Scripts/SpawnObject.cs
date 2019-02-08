using System.Collections;
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
    GameObject crane;

    FixedJoint joint;

    Vector3 priorFrameTransform;

    bool gameOver;
    bool isCloneDropped;

    public bool isReadyToInitiate = true;

    float currentCubePosition;
    float oldCubePosition;

    int score;
    public Text scoreText;
    public Text gameOverScoreText;

    // Use this for initialization
    void Start()
    {
        crane = GameObject.Find("Crane");

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
            // If clone has stopped moving
            if (Vector3.Distance(clone.transform.position, priorFrameTransform) > 0.01f)
            {
                isCloneDropped = true;
                if (clone.transform.position.y < buildingLine.transform.position.y - 0.4)
                {
                    GameOver();
                }
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

        // If second and more clones are spawned
        if (oldClone)
        {
            var currentposition = oldClone.transform.position.y;

            if (currentposition < buildingLine.transform.position.y - 1)
            {
                GameOver();
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
                GameOver();
            }
            oldCubePosition = currentCubePosition;


            if (GameObject.Find("Crane") != null)
            {
                Destroy(crane);
            }

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

    void GameOver()
    {
        gameOverScoreText.text = score.ToString();
        gameOver = true;
        GameManager.GameOver();
        GameOverPanel.SetActive(true);
    }
}
