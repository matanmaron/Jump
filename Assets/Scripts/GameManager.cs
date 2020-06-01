using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public DifficultyEnum Difficulty;
    public int HeightLevel = 0;
    public int TouchLevel = 0;
    public float FallSpeed = 0.05f;
    public bool CanPlay;
    public GameObject Floors;
    public GameObject FloorsHolder;
    public UIManager uiManager;
    private Transform prevPlatform;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        Difficulty = Settings.Difficulty;
        prevPlatform = FloorsHolder.transform;
        StartCoroutine(PlayDelay());
    }

    IEnumerator PlayDelay()
    {
        yield return new WaitForSeconds(3);
        CanPlay = true;
        StartCoroutine(MakeFloor());
    }

    IEnumerator MakeFloor()
    {
        switch (Difficulty)
        {
            case DifficultyEnum.Easy:
                yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
                break;
            case DifficultyEnum.Medium:
                yield return new WaitForSeconds(Random.Range(0.5f, 2.5f));
                break;
            case DifficultyEnum.Hard:
                yield return new WaitForSeconds(Random.Range(0.5f, 3.5f));
                break;
        }
        if (!CanPlay)
        {
            yield return null;
        }
        var randomX = Random.Range(-10, 10f);
        while (Mathf.Abs(randomX - prevPlatform.position.x) < 8)
        {
            randomX = Random.Range(-10, 10f);
        }
        Vector3 pos = new Vector3(randomX, 8, 0);
        var newfloor = Instantiate(Floors, pos, new Quaternion(), FloorsHolder.transform);
        LevelUp();
        prevPlatform = newfloor.transform;
        newfloor.transform.localScale = new Vector3(Random.Range(2f,6f),newfloor.transform.localScale.y, newfloor.transform.localScale.z);
        StartCoroutine(MakeFloor());
    }

    public void GameOver()
    {
        CanPlay = false;
        uiManager.GameOverUI(HeightLevel);
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Menu");
    }

    private void LevelUp()
    {
        uiManager.UpdateLevel(++HeightLevel);
    }
    
    public void TouchLevelUp()
    {
        uiManager.UpdateTouch(++TouchLevel);
    }
}