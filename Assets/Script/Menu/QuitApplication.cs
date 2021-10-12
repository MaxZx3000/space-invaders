using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.LogError("Your application has quit!");
        Application.Quit();
    }
}
