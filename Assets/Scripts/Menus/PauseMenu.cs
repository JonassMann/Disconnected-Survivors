using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject endScreen;
    public TMP_Text goldText;
    public GameObject settingsScreen;

    public Toggle gyroToggle;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (!SystemInfo.supportsGyroscope)
            gyroToggle.interactable = false;
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void EndGame(int goldGained)
    {
        goldText.text = $"Gold Gained: {goldGained}";
        endScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShowSettings()
    {
        pauseScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void CloseSettings()
    {
        pauseScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ToggleGyro()
    {

        Debug.Log(gyroToggle.isOn);
        if (gyroToggle.isOn)
            player.GetComponent<PlayerMovement>().EnableGrav();
        else
            player.GetComponent<PlayerMovement>().DisableGrav();
    }
}
