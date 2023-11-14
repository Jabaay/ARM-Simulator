using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMaster : MonoBehaviour
{

    // script communication
    public SpeedSlider ss;
    public FOVSlider fovs;
    public Missile ms;

    private bool paused = false;

    [SerializeField] private GameObject ptext; // PausedText
    [SerializeField] private GameObject sstext; // SpeedSliderText
    [SerializeField] private GameObject sslider; // SpeedSlider
    [SerializeField] private GameObject bstext; // BoostSliderText
    [SerializeField] private GameObject bslider; // BoostSlider
    [SerializeField] private GameObject rstext; // RadiusSliderText
    [SerializeField] private GameObject rslider; // RadiusSlider
    [SerializeField] private GameObject astext; // AngleSliderText
    [SerializeField] private GameObject aslider; // AngleSlider
    [SerializeField] private GameObject qbutton; // QuitButton
    [SerializeField] private GameObject rbutton; // ResetButton

    [SerializeField] private Text speedText;
    [SerializeField] private Text boostText;
    [SerializeField] private Text radiusText;
    [SerializeField] private Text angleText;
    [SerializeField] private Text distance2TargetText;
    [SerializeField] private Text distance2JammerText;


    // Update is called once per frame
    void Update()
    {
        // Pause the game with the escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed");
            if (!paused)
            {
                paused = true;
                ptext.SetActive(true);
                sstext.SetActive(true);
                sslider.SetActive(true);
                bstext.SetActive(true);
                bslider.SetActive(true);
                rstext.SetActive(true);
                rslider.SetActive(true);
                astext.SetActive(true);
                aslider.SetActive(true);
                qbutton.SetActive(true);
                rbutton.SetActive(true);
                Time.timeScale = 0; // pause the game, percentage
            }
            else
            {
                paused = false;
                ptext.SetActive(false);
                sstext.SetActive(false);
                sslider.SetActive(false);
                bstext.SetActive(false);
                bslider.SetActive(false);
                rstext.SetActive(false);
                rslider.SetActive(false);
                astext.SetActive(false);
                aslider.SetActive(false);
                qbutton.SetActive(false);
                rbutton.SetActive(false);
                Time.timeScale = 1; // resume the game
            }
        }

        // Pass the values to the texts
        speedText.text = "Speed: " + ss._speedSlider.value.ToString("F2");
        boostText.text = "Boost: " + ss._boostSlider.value.ToString("F2");
        radiusText.text = "Radius: " + fovs._radiusSlider.value.ToString("F2");
        angleText.text = "Angle: " + fovs._angleSlider.value.ToString("F2") + "бу";
        distance2TargetText.text = "Distance to Target: " + Vector3.Distance(GameObject.Find("Missile").transform.position, GameObject.Find("Target").transform.position).ToString("F2");
        distance2JammerText.text = "Distance to Jammer: " + Vector3.Distance(GameObject.Find("Missile").transform.position, GameObject.Find("Jammer").transform.position).ToString("F2");

    }

}
