using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI DifficultyText = null;
    [SerializeField] TextMeshProUGUI MusicText = null;
    [SerializeField] TextMeshProUGUI SFXText = null;
    [SerializeField] GameObject MenuPanel = null;
    [SerializeField] GameObject SettingsPanel = null;

    private void Start()
    {
        MenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnDifficultyButton()
    {
        switch (Settings.Difficulty)
        {
            case DifficultyEnum.Easy:
                Settings.Difficulty = DifficultyEnum.Medium;
                break;
            case DifficultyEnum.Medium:
                Settings.Difficulty = DifficultyEnum.Hard;
                break;
            case DifficultyEnum.Hard:
                Settings.Difficulty = DifficultyEnum.Easy;
                break;
        }
        DifficultyText.text = Settings.Difficulty.ToString();
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

    public void OnAboutButton()
    {
        Application.OpenURL("https://matanmaron.wixsite.com/home/about");
    }

    public void OnMusic()
    {
        if (Settings.MuteMusic)
        {
            Settings.MuteMusic = false;
            MusicText.text = "Music: ON";
        }
        else
        {
            Settings.MuteMusic = true;
            MusicText.text = "Music: OFF";
        }
    }

    public void OnSFX()
    {
        if (Settings.MuteSFX)
        {
            Settings.MuteSFX = false;
            SFXText.text = "SFX: ON";
        }
        else
        {
            Settings.MuteSFX = true;
            SFXText.text = "SFX: OFF";
        }
    }

    public void OnSettings()
    {
        MenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void OnSettingsBack()
    {
        MenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
}
