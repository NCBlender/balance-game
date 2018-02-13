using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AveragingScript : MonoBehaviour
{
    
    public int MOVINGAVERAGELENGTH = 20; //made public in case you want to change it in the Inspector, if not, could be declared Constant


    public int RunningAverage(int NewValue, int count, float movingAverage)
    {

        count++;

        //This will calculate the MovingAverage AFTER the very first value of the MovingAverage
        if (count > MOVINGAVERAGELENGTH)
        {
            movingAverage = movingAverage + (NewValue - movingAverage) / (MOVINGAVERAGELENGTH + 1);

            //Debug.Log("Moving Average line 1: " + movingAverage); //for testing purposes
            return Mathf.RoundToInt(movingAverage);

        }
        else
        {
            //NOTE: The MovingAverage will not have a value until at least "MovingAverageLength" values are known (10 values per your requirement)
            movingAverage += NewValue;
            return Mathf.RoundToInt(movingAverage);
            //Debug.Log("Moving Average line 2: " + movingAverage); //for testing purposes

            //This will calculate ONLY the very first value of the MovingAverage,
            if (count == MOVINGAVERAGELENGTH)
            {
                movingAverage += movingAverage / count;
                //Debug.Log("Moving Average line 3: " + movingAverage); //for testing purposes
                return Mathf.RoundToInt(movingAverage);
            }
        }
    }

}