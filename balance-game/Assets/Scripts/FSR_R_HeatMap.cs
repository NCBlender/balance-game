using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSR_R_HeatMap : MonoBehaviour {

  
    private int sensor0;
    private int sensor1;
    private int sensor2;
    private int sensor3;
    private int FSRInputHorizontal;
    private int FSRInputVertical;

    [Range(0.0f,1.0f)]
    public float testFSRValue = .5f;
    public float FSRPercentHorizontal;
    public float FSRPercentVertical;

    public float RFootAP_Percent;

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

        FSRInputVertical = (sensor1 + sensor2) - (sensor0 + sensor3);
        FSRPercentVertical = ((FSRInputVertical) / (1f + sensor0 + sensor1 + sensor2 + sensor3));

        RFootAP_Percent = ((sensor1 - sensor0) / (1f + sensor1 + sensor0));

        h = Input.GetAxis("Horizontal");
        anim.SetFloat("Blend", RFootAP_Percent);

    }



}
