using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    private Transform hoursPivot, minutesPivot, secondsPivot;
    private const float hoursToDegree = -30f, minutesToDegree = -6f, secondsToDegree = -6f;

    private void Awake()
    {   
        // Putting the data all at once in the struct instead of calling it 3 times
        DateTime startTime = DateTime.Now;

        // Quaternion equivalent of a -30º angled Z in euler
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegree * startTime.Hour);
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegree * startTime.Minute);
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegree * startTime.Second);
    }

    void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegree * (float)time.TotalHours);
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegree * (float)time.TotalMinutes);
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegree * (float)time.TotalSeconds);
    }
}
