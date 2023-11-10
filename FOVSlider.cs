using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FOVSlider : MonoBehaviour
{
    // Slider and Text Objects
    [SerializeField] public Slider _radiusSlider;
    [SerializeField] public Slider _angleSlider;

    [SerializeField] private Text _radiusSliderVal;
    [SerializeField] private Text _angleSliderVal;


    // Start is called before the first frame update
    void Update()
    {
        // add listeners to both Sliders to update the texts
        _radiusSlider.onValueChanged.AddListener(OnSliderValue1Changed);
        _angleSlider.onValueChanged.AddListener(OnSliderValue2Changed);
    }


    // Change the value of the radius Slider
    private void OnSliderValue1Changed(float value)
    {
        // update the text of the radius slider
        _radiusSliderVal.text = value.ToString("0.00");
    }

    
    // Change the value of the angle Slider
    private void OnSliderValue2Changed(float value)
    {
        // update the text of the angle slider
        _angleSliderVal.text = value.ToString("0.00");
    }


}
