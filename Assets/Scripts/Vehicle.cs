using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : CollisionObject
{
    [SerializeField] float speed = 30f;
    [SerializeField] Vector3 direction;

    private void OnEnable()
    {
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
