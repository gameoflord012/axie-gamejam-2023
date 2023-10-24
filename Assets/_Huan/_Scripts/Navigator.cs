using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("H_Game");
    }

    public void LoadSettings()
    {

    }

    public void Quit()
    {

    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("H_Menu");
    }    
}