using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRemaining : MonoBehaviour {

    LevelManager levelManager;
    Text text;
    
    void Start()
    {
        text = GetComponent<Text>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        int TimeLeft = (int) levelManager.timeTillNextLevel;
        text.text = "Time: "+ TimeLeft;
    }

}
