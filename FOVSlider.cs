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
        // add listeners to both sliders to update the texts
        _radiusSlider.onValueChanged.AddListener(OnSlider1ValueChanged);
        _angleSlider.onValueChanged.AddListener(OnSlider2ValueChanged);
    }


    // Change the value of radius slider
    private void OnSlider1ValueChanged(float value)
    {
        // update the text of the radius slider
        _radiusSliderVal.text = value.ToString("0.00");
    }


    // Change the value of angle slider
    private void OnSlider2ValueChanged(float value)
    {
        // update the text of the angle slider
        _angleSliderVal.text = value.ToString("0.00");
    }

}
