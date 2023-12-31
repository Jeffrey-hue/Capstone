using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public bool timerActive = false;
    public float currentTime;
    public TextMeshProUGUI timerText;
    public TimeSpan timepass;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        if(GameManager.gameEnded)
        {
            StopTimer();
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timepass = time;
        timerText.text = time.ToString(@"mm\.ss\.fff");
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}

