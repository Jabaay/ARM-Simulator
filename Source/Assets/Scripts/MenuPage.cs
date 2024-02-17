using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPage : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start_Simulator()
    {
        SceneManager.LoadScene("Simulator");
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}
