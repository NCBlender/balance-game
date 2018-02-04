using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck_Movement : MonoBehaviour {

    public float truckSpeed = 4.5f;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * truckSpeed);
    }
}
