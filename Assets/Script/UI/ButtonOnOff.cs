using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnOff : MonoBehaviour
{
    public Slider volumeSlider;
    public GameObject sliderUI;
    private int buttonClickCount = 0;
    private void Start()
    {
        sliderUI.SetActive(false);
    }
    public void OnButtonClick()
    {
        buttonClickCount++;

        if (buttonClickCount % 2 == 1)
        {
            sliderUI.SetActive(true);
        }
        else
        {
            sliderUI.SetActive(false);
        }
    }

}
