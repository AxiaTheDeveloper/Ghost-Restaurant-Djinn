using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCode : MonoBehaviour
{
    public Slider slide;
    public void changeSliderContent(int totalClicked){
        slide.value = totalClicked;
    }
    
    
}
