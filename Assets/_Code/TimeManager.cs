using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public static Action OnDayChanged;

    public static int Minute { get; private set; }
    public static int Hour { get; private set; }

    public static bool Day { get; private set; }

    public static float CurrentTime { get; private set; }

    private float minuteToRealTime = 0.41652f;
    private float timer;
    private int counter;

    void Start()
    {
        Minute = 55;
        Hour = 5;
        Day = false;
        timer = minuteToRealTime;
        counter = 0;
        CurrentTime = 0;
        
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        CurrentTime += Time.deltaTime;

        if (timer <= 0)
        {
            Minute++;
            counter++;
            if (Minute >= 60)
            {
                Hour++;
                Minute = 0;
                if(Hour >= 24)
                {
                    Hour = 0;
                }
                if (Hour >= 6 && Hour < 18 && !Day)
                {
                    Day = true;
                    OnDayChanged?.Invoke();

                    Debug.Log("Es de día: " + Day);

                }
                else if((Hour >= 0 && Hour < 6) || (Hour >= 18 && Hour <=23 ) && Day)
                {
                    Day = false;
                    OnDayChanged?.Invoke();

                    Debug.Log("Es de día: " + Day);
                    
                }

            }

            if (counter >= 5)
            {
                counter = 0;
                OnMinuteChanged?.Invoke();

            }

            timer = minuteToRealTime;
        }
    }

    /// <summary>
    /// para que no se elimine al cambiar de escena
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
