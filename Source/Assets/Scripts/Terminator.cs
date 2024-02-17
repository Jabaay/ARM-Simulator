using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminator : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit the game!");
    }
}
