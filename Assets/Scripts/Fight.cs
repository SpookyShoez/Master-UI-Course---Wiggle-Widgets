using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{
    public Slider slider;


    public void SetRandomValue() {
        float startValue = slider.value;
        float newValue = Random.Range(slider.minValue, slider.maxValue);
        slider.value = newValue;

        LeanTween.value(gameObject, startValue, newValue, 1f).setOnUpdate((float val) => {
            slider.value = val;
        }).setEaseInOutExpo();
    }
}
