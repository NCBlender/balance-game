using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

    public int score;

    private void Start()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        score++;
        //print(score);
    }

}
