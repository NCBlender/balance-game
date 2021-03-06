﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSRInput_lateral_AP_rotate : MonoBehaviour {

    private float moveSpeed;
    private Animator anim;
    public AudioSource audioSound;
    public AudioClip skateRight;
    public AudioClip coasting;
    public AudioClip skateLeft;
    public AudioClip[] woah;
    private bool hit;
    //private btle_controller Btlecontroller;
    private int sensor0;
    private int sensor1;
    private int sensor2;
    private int sensor3;
    private int FSRInputHorizontal;
    private int FSRInputVertical;
    private float FSRPercentHorizontal;
    private float FSRPercentVertical;
    private int FSRInputRotation;
    private float FSRPercentRotation;

    public float testFSRValue = .5f;
    public float rotateSpeed = 36f;
    public float sidespeed = 1f;


    void Start () {
        anim = GetComponent<Animator>();
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

        FSRInputRotation = (sensor0 + sensor2) - (sensor1 + sensor3);
        FSRPercentRotation = ((FSRInputRotation) / (1f + sensor0 + sensor1 + sensor2 + sensor3));




        transform.Translate(sidespeed * FSRPercentHorizontal * Time.deltaTime, 0, sidespeed * FSRPercentVertical * Time.deltaTime);//for FSR controller
        //transform.Translate(sidespeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, rotateSpeed * Input.GetAxis("Vertical") * Time.deltaTime);//testing

        transform.Rotate(0, rotateSpeed * FSRPercentRotation * Time.deltaTime, 0);

       
        if (hit == true)
        {
            //anim.SetBool("isFlailing", true);
            audioSound.clip = woah[Random.Range(0, woah.Length)];
            audioSound.Play();
            hit = !hit;
            anim.SetBool("isFlailing", false);
            //Debug.Log("Hit = false now?");
        }

        

      
    }

        void OnTriggerEnter(Collider other)
    {
        hit = true;
    }

}
