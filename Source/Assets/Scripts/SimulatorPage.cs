using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SimulatorPage : MonoBehaviour
{
    public GameObject settingsPopup;
    public Dropdown missileTypeDropdown;
    public Dropdown radarTypeDropdown;

    // Toggle the settings popup
    public void OpenPopup()
    {
        // Show the popup window
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
