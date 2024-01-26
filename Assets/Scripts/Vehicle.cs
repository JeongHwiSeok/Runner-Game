using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : CollisionObject
{
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;

    [SerializeField] float minRandomSpeed = 5f;
    [SerializeField] float maxRandomSpeed = 20f;

    public float Speed
    {
        get { return speed; }

        set { speed = value; }
    }

    private void OnEnable()
    {
        if(minRandomSpeed < 19)
        {
            minRandomSpeed += 1;
        }

        direction = Vector3.forward;
        speed = GameManager.instance.Speed + Random.Range(minRandomSpeed, maxRandomSpeed);
    }

    private void Update()
    {
        if (GameManager.instance.state == false)
        {
            return;
        }

        transform.Translate(direction * speed * Time.deltaTime);
    }

    public override void Activate(Runner runner)
    {
        runner.animator.Play("Die");

        GameManager.instance.GameOver();
    }
}
