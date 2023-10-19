using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public string levelIndex;
    public int levelToUnlock = 2;

    public void Menu ()
    {
        levelIndex = "MainMenu";
        StartCoroutine(Load(levelIndex));
    }

    public void Continue()
    {
        levelIndex = "Level Select";
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
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
