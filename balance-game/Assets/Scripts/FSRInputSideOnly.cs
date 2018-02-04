using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSRInputSideOnly : MonoBehaviour {

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

    public float testFSRValue = .5f;
    public float forwardspeed = 2f;
    public float sidespeed = 2f;

    private float translation;


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

        //FSR test of proportional movement
        float step = moveSpeed * Time.deltaTime;
        //transform.position = Vector3.Lerp(transform.position, new Vector3(FSRPercentHorizontal * 77f, transform.position.y, transform.position.z), step);


     
               
        transform.Translate(sidespeed * FSRPercentHorizontal * Time.deltaTime, 0, forwardspeed * Time.deltaTime);


        if ((FSRPercentHorizontal > .4)&&(FSRPercentHorizontal < .6))
        {
            anim.SetBool("istwoFeet", true);
            anim.SetBool("isSkatingRight", false);
            anim.SetBool("isSkatingLeft", false);
            anim.SetBool("isFlailing", false);
            if (!audioSound.isPlaying)
            {
                audioSound.PlayOneShot(coasting);
            }
        }


        if (FSRPercentHorizontal < .4)
        {
            anim.SetBool("isSkatingLeft", true);
            anim.SetBool("isSkatingRight", false);
            anim.SetBool("istwoFeet", false);
            anim.SetBool("isFlailing", false);
            if (!audioSound.isPlaying)
            {
                audioSound.PlayOneShot(skateLeft);
                //print("playaudio");
            }
        }

        if (FSRPercentHorizontal > .6)
        {
            anim.SetBool("isSkatingRight", true);
            anim.SetBool("isSkatingLeft", false);
            anim.SetBool("istwoFeet", false);
            anim.SetBool("isFlailing", false);
            if (!audioSound.isPlaying)
            {
                audioSound.PlayOneShot(skateLeft);
                print("playaudio");
            }
        }

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
