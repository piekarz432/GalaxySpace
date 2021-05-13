using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderManager : MonoBehaviour
{
    public void sliderValueChangeHandler(GameObject slider, float value)
    {
        Debug.Log("Slider name: " + slider.gameObject.transform.name);
        Debug.Log("Slider value: " + value);
    }
}