using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadBox : CollisionObject
{
    [SerializeField] private float initSpeed;
    [SerializeField] UnityEvent callback;

    private void Start()
    {
        initSpeed = GameManager.instance.Speed;
    }

    public override void Activate(Runner runner)
    {
        runner.animator.speed = (GameManager.instance.Speed - 10) / initSpeed;

        DataManager.instance.data.score += 10;
        DataManager.instance.Save();

        callback.Invoke();

        GameManager.instance.IncreaseSpeed();
    }
}
