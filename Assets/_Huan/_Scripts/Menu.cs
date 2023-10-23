using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnStartGameButton()
    {
        SceneManager.LoadScene("H_Game");
    }

    public void OnSettingsButton()
    {

    }

    public void OnQuitButton()
    {

    }
}
