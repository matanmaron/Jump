using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Level = 0;
    public float FallSpeed = 0.05f;
    public bool CanPlay;
    public GameObject Floors;
    public GameObject FloorsHolder;
    public UIManager uiManager;

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
        yield return new WaitForSeconds(Random.Range(0.5f,3f));
        if (!CanPlay)
        {
            yield return null;
        }
        Vector3 pos = new Vector3(Random.Range(-10, 10f), 8, 0);
        var newfloor = Instantiate(Floors, pos, new Quaternion(), FloorsHolder.transform);
        newfloor.transform.localScale = new Vector3(Random.Range(2f,6f),newfloor.transform.localScale.y, newfloor.transform.localScale.z);
        StartCoroutine(MakeFloor());
    }

    public void GameOver()
    {
        CanPlay = false;
        uiManager.GameOverUI(Level);
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }

    public void LevelUp()
    {
        uiManager.UpdateLevel(++Level);
    }
}