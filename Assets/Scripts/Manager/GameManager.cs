using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private float speed = 1f;
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
}
