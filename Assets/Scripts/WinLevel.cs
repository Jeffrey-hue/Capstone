using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public string levelIndex;
    public int levelToUnlock;
    public WaveSpawner wave;
    public GameObject UI;

    public void Menu ()
    {
        levelIndex = "MainMenu";
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        StartCoroutine(Load(levelIndex));
    }

    public void Continue()
    {
        wave.waveIndex = 0;
        levelIndex = "Level Select";
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        StartCoroutine(Load(levelIndex));
        StartCoroutine(Loading());
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

   IEnumerator Loading()
   {
        yield return new WaitForSeconds(5);
        UI.SetActive(false);
   }
}
