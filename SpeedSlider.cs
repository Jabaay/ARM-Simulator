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
        _speedSlider.onValueChanged.AddListener(OnSlider1ValueChanged);
        _boostSlider.onValueChanged.AddListener(OnSlider2ValueChanged);
    }


    // Change the value of speed Slider
    private void OnSlider1ValueChanged(float value)
    {
        // update the text of the speed slider
        _speedSliderVal.text = value.ToString("0.00");
    }


    // Change the value of boost Slider
    private void OnSlider2ValueChanged(float value)
    {
        // update the text of the boost slider
        _boostSliderVal.text = value.ToString("0.00");
    }

}