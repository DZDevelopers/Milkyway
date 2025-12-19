using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void Button_Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    public void Button_Settings()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Settings");
    }
    public void Button_Quit()
    {
        Application.Quit();
    }
}
