using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public static bool IsGameStarted = false;
    public static bool IsGameOver = false;
    public static int loaded = 0;

    public GameObject Canvas;
    public GameObject GameOverCanvas;
    public GameObject cameraGameObject;

    void Start () {
        FadeIn();
        Screen.SetResolution(640, 1136, false);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void DelayGameStart()
    {
        StartCoroutine(DelayedGameStart());
        StartCoroutine(DestroyMenuItems());
    }

    public void StartGame()
    {

        IsGameOver = false;
        IsGameStarted = true;
        Canvas.SetActive(false);
    }

    public static void GameOver()
    {
        IsGameStarted = false;
        IsGameOver = true;
        //ReloadGame();
    }

    IEnumerator DestroyMenuItems()
    {
        yield return new WaitForSeconds(1f);

        var items = GameObject.FindGameObjectsWithTag("MenuPrefab");
        foreach (var item in items)
        {
            Destroy(item);
        }
    }

    IEnumerator DelayedGameStart()
    {
        FadeOut();
        yield return new WaitForSeconds(1.5f);
        FadeIn();
        StartGame();
    }

    public void ReloadGame()
    {
        StartCoroutine(DelayedFadeOut());
    }

    IEnumerator DelayedFadeOut()
    {
        cameraGameObject.GetComponent<FadeCamera>().FadeOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void FadeOut()
    {
        cameraGameObject.GetComponent<FadeCamera>().FadeOut();
    }

    public void FadeIn()
    {
        cameraGameObject.GetComponent<FadeCamera>().FadeIn(3f);
    }
}
