using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : CollisionObject
{
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;

    public float Speed
    {
        get { return speed; }

        set { speed = value; }
    }

    private void OnEnable()
    {
        speed = GameManager.instance.Speed + Random.Range(20, 31);
        direction = Vector3.forward;
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
