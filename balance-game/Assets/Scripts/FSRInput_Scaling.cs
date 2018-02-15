using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSRInput_Scaling : MonoBehaviour
{
    public int MOVINGAVERAGELENGTH = 20;

    public GameObject cube0;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;

    public float moveSpeed = 4f;

    private int sensor0;
    private int sensor1;
    private int sensor2;
    private int sensor3;

    private int count0;
    private int count1;
    private int count2;
    private int count3;

    private float movingAverage0;
    private float movingAverage1;
    private float movingAverage2;
    private float movingAverage3;


   void Update()
    {

        sensor0 = btle_controller.FSR0;
        sensor1 = btle_controller.FSR1;
        sensor2 = btle_controller.FSR2;
        sensor3 = btle_controller.FSR3;
        

        ScaleThis(cube0, sensor0);
        ScaleThis(cube1, sensor1);
        ScaleThis(cube2, sensor2);
        ScaleThis(cube3, sensor3);

       

    }

    public Vector3 ScaleThis(GameObject cube, int sensor)
    {
        cube.transform.localScale = new Vector3(1, sensor*.005f + .2f, 1);
        return cube.transform.localScale;
    }

}






