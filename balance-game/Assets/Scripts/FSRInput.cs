using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSRInput : MonoBehaviour {

    public AudioSource audioSound;
    public AudioClip[] woah;
    public float moveSpeed = 4f;
    private bool hit;
    //private btle_controller Btlecontroller;
    private int sensor0;
    private int sensor1;
    private int sensor2;
    private int sensor3;
    private int FSRInputHorizontal;
    private int FSRInputVertical;


    public float testFSRValue = .5f;
    public float FSRPercentHorizontal;
    public float FSRPercentVertical;

    public Camera cameraMain;
   
    void Start () {
   
    }


    void FixedUpdate() {

        sensor0 = btle_controller.FSR0;
        sensor1 = btle_controller.FSR1;
        sensor2 = btle_controller.FSR2;
        sensor3 = btle_controller.FSR3;

        FSRInputHorizontal = (sensor0 + sensor1) - (sensor2 + sensor3);
        FSRPercentHorizontal = ((FSRInputHorizontal) / (1f + sensor0 + sensor1 + sensor2 + sensor3));

        FSRInputVertical = (sensor1 + sensor2) - (sensor0 + sensor3);
        FSRPercentVertical = ((FSRInputVertical) / (1f + sensor0 + sensor1 + sensor2 + sensor3));

        //FSR test of proportional movement
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, new Vector3(FSRPercentHorizontal * 77f, FSRPercentVertical * 55f, transform.position.z), step);



        //Keyboard test of proportional movement
        //transform.position = Vector3.Lerp(transform.position, new Vector3(testFSRValue * screenWidth, transform.position.y, transform.position.z), step);



        //transform.Translate(moveSpeed * (sensor1 - sensor2) * Time.deltaTime, 0f, 0f); //works but jittery collissions
        //rb.MovePosition(transform.position + new Vector3(moveSpeed * FSRInputSpeed * Time.deltaTime, 0f, 0f));
        //rb.velocity = new Vector3(moveSpeed * (sensor1 - sensor2) * Time.deltaTime, 0f, 0f); //works but isn't proportional
    

     
        //transform.position = Vector3.Lerp(transform.position, endMarker.position, journeyLength * Time.deltaTime); //takes market back to center
        

        if (hit == true)
        {
            audioSound.clip = woah[Random.Range(0, woah.Length)];
            audioSound.Play();
            hit = !hit;
            //Debug.Log("Hit = false now?");
        }
    }

        void OnTriggerEnter(Collider other)
    {
        hit = true;
    }

}
