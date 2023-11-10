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
        _radiusSlider.onValueChanged.AddListener(OnSliderValueChanged);
        _angleSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }


    // Change the value of the Sliders
    private void OnSliderValueChanged(float value)
    {
        // update the text of the radius slider
        _radiusSliderVal.text = value.ToString("0.00");
        _angleSliderVal.text = value.ToString("0.00");
    }


}
