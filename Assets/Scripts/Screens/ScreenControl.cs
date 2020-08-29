using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenControl : MonoBehaviour
{

    public void CallScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}   
