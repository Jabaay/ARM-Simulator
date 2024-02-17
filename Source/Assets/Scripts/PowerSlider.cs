using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour
{

    // Slider and Text Objects
    [SerializeField] public Slider _statusSlider; // status
    [SerializeField] public Slider _powerSlider; // power

    [SerializeField] private Text _powerSliderVal;

    public string jmrsts;

    // Start is called before the first frame update
    void Update()
    {
        // add listeners to both Sliders to update the texts
        _powerSlider.onValueChanged.AddListener(OnSliderValue3Changed);
        _getStatus();
    }


    // Change the value of the power Slider
    private void OnSliderValue3Changed(float value)
    {
        // update the text of the boost slider
        _powerSliderVal.text = value.ToString("0.00");
    }

    // Get the value of the power Slider
    public void _getStatus()
    {
        // Get Jammer Status off the statusSlider value.
        jmrsts = _statusSlider.value == 0 ? "OFF" : "ON";
        
    }
}