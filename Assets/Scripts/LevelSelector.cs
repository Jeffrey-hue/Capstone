using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public string levelIndex;
    
    public void Alabasta()
    {
        levelIndex = "Level1";
        StartCoroutine(LoadScene(levelIndex));
    }

    public void Cake()
    {
        levelIndex = "Level2";
        StartCoroutine(LoadScene(levelIndex));
    }

    public void Dress()
    {
        levelIndex = "Level3";
        StartCoroutine(LoadScene(levelIndex));
    }

    IEnumerator LoadScene(string levelIndex)
   {
        //play
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(2);
        //load
        SceneManager.LoadScene(levelIndex);
   }
}
