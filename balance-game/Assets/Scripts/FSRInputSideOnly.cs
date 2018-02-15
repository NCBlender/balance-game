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
    
    public float testFSRValue = .5f;
    public float forwardspeed = 2f;
    public float sidespeed = 2f;

    private float translation;

    [Range(0, 1)]
    public float testRange;


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

             
        transform.Translate(sidespeed * FSRPercentHorizontal * Time.deltaTime, 0, forwardspeed * Time.deltaTime);
        
        if ((FSRPercentHorizontal > .2)&&(FSRPercentHorizontal < .8))
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


        else if (FSRPercentHorizontal < .2)
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

        else if (FSRPercentHorizontal > .8)
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
            anim.SetBool("isFlailing", true);
            audioSound.clip = woah[Random.Range(0, woah.Length)];
            audioSound.Play();
            hit = !hit;
            //anim.SetBool("isFlailing", false);
            Debug.Log("Hit");
        }

        

      
    }

        void OnTriggerEnter(Collider other)
    {
        hit = true;
    }

}
