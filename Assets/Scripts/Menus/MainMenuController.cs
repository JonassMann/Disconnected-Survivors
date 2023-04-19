using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject settingsScreen;

    public GameObject activeScreen;

    public Toggle gyroToggle;

    private void Start()
    {
        if (!SystemInfo.supportsGyroscope)
        {
            Debug.Log("No gyro");
            gyroToggle.interactable = false;
        }

        if (PlayerPrefs.HasKey("useGrav"))
        {
            if (PlayerPrefs.GetInt("useGrav") == 0)
                gyroToggle.isOn = false;
            else if (PlayerPrefs.GetInt("useGrav") == 1)
                gyroToggle.isOn = true;
        }
    }

    public void PlayGame()
    {
        Time.timeScale = 1.0f;
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

    public void ToggleGyro()
    {
        if (gyroToggle.isOn)
            PlayerPrefs.SetInt("useGyro", 1);
        else
            PlayerPrefs.SetInt("useGyro", 0);
    }
}
