using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    public Slider brightnessSlider;

    private void Start()
    {
        brightnessSlider.onValueChanged.AddListener(OnBrightnessChanged);
    }

    private void OnBrightnessChanged(float brightness)
    {
        RenderSettings.ambientIntensity = brightness;
    }
}