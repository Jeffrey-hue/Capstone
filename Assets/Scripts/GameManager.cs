using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameEnded;
    public GameObject gameOverUI;
    public GameObject shopUI;
    public string nextLevel = "Level2";
    public int levelToUnlock = 2;
    void Start ()
    {
        gameEnded = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameEnded){
            return;
        }
        if (PlayerStats.Lives <= 0)
        {
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
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }
    
}
