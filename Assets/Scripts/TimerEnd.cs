using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerEnd : MonoBehaviour
{
    public Timer timer;
    public TMP_Text timeTxt;
    void Awake ()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText ()
    {
        timeTxt.text = "0";
        int time = 0;

        yield return new WaitForSeconds(.7f);
        while(time < timer.currentTime)
        {
            time++;
            timeTxt.text = timer.timepass.ToString(@"mm\.ss\.fff");

            yield return new WaitForSeconds(.05f);
        }
    }
}
