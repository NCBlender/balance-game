using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{

    Text text;
    private PlayerTargetTimer playerTargetTimer;
    private bool timerStarted;
    public int TimerValue;


    void Start()
    {
        text = GetComponent<Text>();
        playerTargetTimer = FindObjectOfType<PlayerTargetTimer>();
        
    }



    void Update()
    {
        timerStarted = playerTargetTimer.TimerStarted;
        TimerValue = (Mathf.RoundToInt(playerTargetTimer.timer));
        
        if (timerStarted == true){
                text.text = TimerValue.ToString(); 
        }
        else if (timerStarted == false)
        {
            text.text = "";
        }
    }
}

