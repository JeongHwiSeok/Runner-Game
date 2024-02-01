using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float limitSpeed = 50f;
    [SerializeField] public bool state = true;

    public float minRandomSpeed = 5f;
    public float maxRandomSpeed = 20f;

    private Transform parent;
    private GameObject panel;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public void ControlRandomSpeed()
    {
        if(minRandomSpeed < maxRandomSpeed)
        {
            minRandomSpeed++;
        }
    }

    public void GameOver()
    {
        parent = GameObject.Find("UI Canvas").GetComponent<Transform>();

        state = false;

        if (panel == null)
        {
            panel = Instantiate(Resources.Load<GameObject>("GameOver Panel"), parent);
        }
        else
        {
            panel.SetActive(true);
        }
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
        state = true;
        speed = 20;

        Time.timeScale = 1.0f;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= onSceneLoaded;
    }
}
