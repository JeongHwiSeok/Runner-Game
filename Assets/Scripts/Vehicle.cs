using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
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
        direction = Vector3.forward;

        GameManager.instance.ControlRandomSpeed();

        speed = GameManager.instance.Speed + Random.Range(GameManager.instance.minRandomSpeed, GameManager.instance.maxRandomSpeed);
    }

    private void Update()
    {
        if (GameManager.instance.state == false)
        {
            return;
        }

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
