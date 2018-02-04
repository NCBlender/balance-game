using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {

    ScoreKeeper scoreKeeper;
    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Hits: " + scoreKeeper.score;
	}
}
