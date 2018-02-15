using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSR_L_HeatMap : MonoBehaviour {

  
    private int sensor0;
    private int sensor1;
    private int sensor2;
    private int sensor3;
    private int FSRInputHorizontal;
    private int FSRInputVertical;

    [Range(0.0f,1.0f)]
    public float testFSRValue = .5f;
    public float FSRPercentHorizontal;
    

    public float LFootAP_Percent;

    private Animator anim;
    private float h;
      
   
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

       LFootAP_Percent = ((sensor2 - sensor3) / (1f + sensor2 + sensor3));

        h = Input.GetAxis("Horizontal");
        anim.SetFloat("Blend", LFootAP_Percent);

    }



}
