using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceTargetMovement : MonoBehaviour {

    //public float moveSpeed = 1;
    //public Rigidbody rb;

    
    public Transform endMarker;
    public float smoothing = 1f;
    
    
    // Use this for initialization
    void Start () {
        //rb = GetComponent<Rigidbody>();
        //rb.AddForce(Random.Range(.00004f, .0002f), Random.Range(.00004f, .0002f), 0); //Works with rb equation below

        InvokeRepeating("ChangePosition", 0, 2);
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(new Vector3((rb.velocity.x) + moveSpeed, (rb.velocity.y) + moveSpeed, 0) * Time.deltaTime * moveSpeed, Space.World);
        transform.position = Vector3.MoveTowards(transform.position, endMarker.position, smoothing * Time.deltaTime);
    }


    void ChangePosition()
    {
                endMarker.position = new Vector3(Random.Range(-120, 120), Random.Range(-90, 90), 100);
    }
        

}
  

