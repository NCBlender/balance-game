using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeperLeft : MonoBehaviour {

    public int score;
    public bool Left;

    private void Start()
    {
        
        Left = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "TargetLeft")
        {
            score++;
            Left = true;
            //print(score);
        }
        else {
            Left = false;
        }
        
    }
}
