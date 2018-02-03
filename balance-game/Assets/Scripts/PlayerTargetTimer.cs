using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTargetTimer : MonoBehaviour
{

    public bool TimerStarted = false;
    public float timer = 0;
    public float TimeIWantInSeconds = 10f;
    public Text UITimer;


    void Start()
    {
        UITimer = GetComponent<Text>();
        
    }

    void OnTriggerEnter (Collider other)
    {
        if (!TimerStarted)
        {
            TimerStarted = true;
            //Debug.Log("collission detected");
            
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        TimerStarted = !TimerStarted;
        //Debug.Log("collission exited");
        
        timer = 0f;

    }


    void Update()
    {
        if (TimerStarted)
        {
            timer += Time.deltaTime;


            if (timer >= TimeIWantInSeconds)
            {
                //Do whatever since the time has elapsed. Create a particle system horray?
            }
        }        
    }
}