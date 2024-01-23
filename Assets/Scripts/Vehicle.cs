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
        speed = Random.Range(5, 41);
        direction = Vector3.forward;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public override void Activate(Runner runner)
    {
        Debug.Log("Game Over");
    }
}
