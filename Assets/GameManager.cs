using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public static bool IsGameStarted = false;
    public static bool IsGameOver = false;

    public GameObject Canvas;

    void Start () {
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
        yield return new WaitForSeconds(1.5f);
        StartGame();
    }
}
