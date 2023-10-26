using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public WaveSpawner waves;
    public static bool gameEnded;
    public GameObject gameOverUI;
    public GameObject WinUI;
    public GameObject shopUI;
    public string nextLevel = "Level2";
    public int levelToUnlock = 2;
    void Start ()
    {
        gameEnded = false;
        waves.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameEnded){
            Debug.Log("ugh");
            return;
        }
        if (PlayerStats.Lives <= 0)
        {
            waves.enabled = false;
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
        shopUI.SetActive(false);
    }

    public void WinLevel()
    {
        gameEnded = true;
        WinUI.SetActive(true);
        shopUI.SetActive(false);
    }
    
}
