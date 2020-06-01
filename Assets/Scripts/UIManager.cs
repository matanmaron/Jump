using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI StartUpText;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI TouchLevelText;

    void Start()
    {
        StartUpText.text = string.Empty;
        StartCoroutine(TextDelay());
    }

    IEnumerator TextDelay()
    {
        StartUpText.text = "3";
        yield return new WaitForSeconds(1);
        StartUpText.text = "2";
        yield return new WaitForSeconds(1);
        StartUpText.text = "1";
        yield return new WaitForSeconds(1);
        StartUpText.text = string.Empty;
    }

    public void GameOverUI(int height)
    {
        StartUpText.text = $"Game Over ! Top Level: {height}";
    }

    public void UpdateLevel(int level)
    {
        LevelText.text = $"Level: {level}";
    }  
    
    public void UpdateTouch(int touch)
    {
        TouchLevelText.text = $"Touch: {touch}";
    }
}