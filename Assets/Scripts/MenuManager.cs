using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI DifficultyText = null;
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
}
