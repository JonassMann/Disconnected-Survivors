using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject settingsScreen;

    public GameObject activeScreen;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void ShowScreen(GameObject screen)
    {
        activeScreen.SetActive(false);
        activeScreen = screen;
        activeScreen.SetActive(true);
    }

    public void ShowSettings()
    {
        settingsScreen.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsScreen.SetActive(false);
    }
}
