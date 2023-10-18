using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text roundTxt;
    public Animator transition;
    public float transitionTime = 1f;
    public string levelIndex;
    
    void Awake ()
    {
        roundTxt.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        levelIndex = "Level1";
        StartCoroutine(Load(levelIndex));
    }
    public void Menu()
    {
        levelIndex = "MainMenu";
        StartCoroutine(Load(levelIndex));
    }

    IEnumerator Load(string levelIndex)
   {
        //play
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(2);
        //load
        SceneManager.LoadScene(levelIndex);
   }
}
