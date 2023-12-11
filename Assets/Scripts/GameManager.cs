using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Timer timer;
    public Animator cam;
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
        cam.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("p"))
        {
            WinLevel();
        }
        if (gameEnded){
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
        StartCoroutine(WinAnim());
    }

    IEnumerator WinAnim()
   {
        cam.enabled = true;
        cam.SetTrigger("g");
        yield return new WaitForSeconds(3);
        WinUI.SetActive(true);
        shopUI.SetActive(false);
   }
    
}
