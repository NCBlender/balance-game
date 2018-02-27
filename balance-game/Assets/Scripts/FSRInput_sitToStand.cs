using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSRInput_sitToStand : MonoBehaviour {
      

       
    private int sensor0;
    private int sensor1;
    private int sensor2;
    private int sensor3;

    private int FSRInputHorizontal;
    private int FSRInputVertical;

    private Animator anim;
    public int count = 0;
    private bool standUp;


    private float FSRPercentHorizontal;
    private float FSRPercentVertical;

  
    void Start () {
        anim = GetComponent<Animator>();
        
    }


    void Update() {

        sensor0 = btle_controller.FSR0;
        sensor1 = btle_controller.FSR1;
        sensor2 = btle_controller.FSR2;
        sensor3 = btle_controller.FSR3;

        
        FSRInputHorizontal = (sensor0 + sensor1) - (sensor2 + sensor3);
        FSRPercentHorizontal = ((FSRInputHorizontal) / (1f + sensor0 + sensor1 + sensor2 + sensor3));

        FSRInputVertical = (sensor1 + sensor2) - (sensor0 + sensor3);
        FSRPercentVertical = ((FSRInputVertical) / (1f + sensor0 + sensor1 + sensor2 + sensor3));


     
        if (count == 5)
        {
            anim.SetTrigger("walkOut");
            
        }

        else if (sensor0 + sensor1 + sensor2 + sensor3 < 1000)
        {
            anim.SetBool("sitDown", true);
        }
        else
        {
            anim.SetBool("sitDown", false);
        }
        
        
    }

    void StandUpCounter()
    {
        count = count + 1;
       
    }
    
}
