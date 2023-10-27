using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("H_Game");
        Time.timeScale = 1f;
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

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        // Do continue game
        Time.timeScale = 1f;
    }
}
