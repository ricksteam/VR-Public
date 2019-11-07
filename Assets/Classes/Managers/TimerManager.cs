using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Responsible for calling functions related to timers.
//Useful for games where time is used for scoring instead of points.
public class TimerManager : MonoBehaviour
{
    private float timer;
    public float timerUpdateInterval = .1f;
    private float timerStartTime;

    //Starts counting from current value of timer
    public void resumeTimer()
    {
        timerStartTime = -timer;
        StartCoroutine(countUp());
    }

    //Stops counting
    public void pauseTimer() { StopCoroutine(countUp()); }

    //Starts counting from 0
    public void startTimer()
    {
        stopTimer();
        timerStartTime = Time.realtimeSinceStartup;
        resumeTimer();
    }

    //Stops counting and sets timer to 0
    public void stopTimer()
    {
        pauseTimer();
        timer = 0;
    }

    //Coroutine for incrementing timer over time
    private IEnumerator countUp()
    {
        while (true)
        {
            timer = Time.realtimeSinceStartup - timerStartTime;
            print(timer);
            yield return new WaitForSeconds(timerUpdateInterval);
        }
    }
}
