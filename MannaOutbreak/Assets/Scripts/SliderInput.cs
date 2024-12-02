using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderInput : MonoBehaviour
{
    public Slider Slider;
    public GameObject SliderText;

    public void SliderRead(){
        SliderText.GetComponent<Text>().text = Slider.value.ToString() + "%";
        GlobalVar.InfectionRate = Mathf.RoundToInt(Slider.value);
    }
}
