using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SitToStandCount : MonoBehaviour {

    Text text;
    FSRInput_sitToStand fSRInput_sitToStand;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        fSRInput_sitToStand = FindObjectOfType<FSRInput_sitToStand>();
    }
	
	// Update is called once per frame
	void Update () {
        int StandCount = fSRInput_sitToStand.count;
        text.text = "You stood up " + StandCount + " times!";
	}
}
