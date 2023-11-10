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
        _speedSlider.onValueChanged.AddListener(OnSliderValueChanged);
        _boostSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }


    // Change the value of the Sliders
    private void OnSliderValueChanged(float value)
    {
        // update the text of the speed slider
        _speedSliderVal.text = value.ToString("0.00");
        _boostSliderVal.text = value.ToString("0.00");
    }


}