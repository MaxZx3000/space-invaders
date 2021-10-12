using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float finishTime;
    private float startTime;
    public void initializeCurrentTime(float seconds)
    {
        startTime = Time.time;
        finishTime = startTime + seconds;
    }
    public bool determineIfFinished()
    {
        if (startTime >= finishTime)
        {
            return true;
        }
        startTime = Time.time;
        return false;
    }

}
