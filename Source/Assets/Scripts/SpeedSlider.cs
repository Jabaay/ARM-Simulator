using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour
{
    // Slider and Text Objects
    [SerializeField] public Slider _speedSlider; // speed
    [SerializeField] public Slider _boostSlider; // boost

    [SerializeField] private Text _speedSliderVal;
    [SerializeField] private Text _boostSliderVal;


    // Start is called before the first frame update
    void Update()
    {
        // add listeners to both Sliders to update the texts
        _speedSlider.onValueChanged.AddListener(OnSliderValue1Changed);
        _boostSlider.onValueChanged.AddListener(OnSliderValue2Changed);
    }


    // Change the value of the speed Slider
    private void OnSliderValue1Changed(float value)
    {
        // update the text of the speed slider
        _speedSliderVal.text = value.ToString("0.00");
    }


    // Change the value of the boost Slider
    private void OnSliderValue2Changed(float value)
    {
        // update the text of the boost slider
        _boostSliderVal.text = value.ToString("0.00");
    }

}