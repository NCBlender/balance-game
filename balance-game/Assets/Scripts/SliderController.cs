using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SliderController : MonoBehaviour {

    public GameObject marker;
    public GameObject target;
    public GameObject TimeInTarget;
    public GameObject HighScore;
    public GameObject SineWave;





    public void markerSize(float newValue)
    {
        Vector3 scale = marker.transform.localScale;
        scale.x = newValue;
        scale.y = newValue;
        marker.transform.localScale = scale;
    }

    public void targetSize(float newValue)
    {
        Vector3 scale = target.transform.localScale;
        scale.x = newValue;
        scale.y = newValue;
        target.transform.localScale = scale;
    }

    public void toggleTrails (bool newValue)
    {
        marker.GetComponent<TrailRenderer>().enabled=newValue;
        //target.SetActive(newValue);
    }

    public void HideTarget(bool newValue)
    {
        target.SetActive(newValue);
        TimeInTarget.SetActive(newValue);
        HighScore.SetActive(newValue);
    }

    public void SoundOn(bool newValue)
    {
        SineWave.SetActive(newValue);
    }


}
