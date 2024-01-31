using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float limitSpeed = 50f;
    [SerializeField] public bool state = true;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public void GameOver()
    {
        state = false;
    }

    public void IncreaseSpeed()
    {
        if(speed < limitSpeed)
        {
            speed++;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += onSceneLoaded;
    }

    void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1.0f;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= onSceneLoaded;
    }
}
