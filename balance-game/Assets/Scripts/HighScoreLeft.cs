using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreLeft : MonoBehaviour {

    ScoreKeeperLeft scoreKeeperLeft;
    UI_Timer uI_Timer;
    Text text;
    
    // Use this for initialization
    void Start () {
        PlayerPrefs.DeleteAll();
        text = GetComponent<Text>();
        scoreKeeperLeft = FindObjectOfType<ScoreKeeperLeft>();
        uI_Timer = FindObjectOfType<UI_Timer>();
        text.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        if ((scoreKeeperLeft.Left == true) && (uI_Timer.TimerValue > PlayerPrefs.GetInt("HighScoreLeft", 0)))
        {
            PlayerPrefs.SetInt("HighScoreLeft", uI_Timer.TimerValue);
            text.text = "High Score: " + uI_Timer.TimerValue.ToString();
        }

    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        text.text = "";
    }
}
