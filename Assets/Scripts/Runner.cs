using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE,
    RIGHT
}

public class Runner : MonoBehaviour
{
    public Animator animator;

    [SerializeField] RoadLine roadLine;

    [SerializeField] public float maxWidth = 2.25f;

    [SerializeField] public float lerpspeed = 25.0f;

    [SerializeField] LeftCollider leftCollider;
    [SerializeField] RightCollider rightCollider;

    private void Start()
    {
        InputManager.instance.keyAction += Move;
        roadLine = RoadLine.MIDDLE;
    }

    private void Update()
    {
        Status();
    }

    private void Move()
    {
        if (GameManager.instance.state == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (leftCollider.TriggerCheck)
            {
                return;
            }

            if (roadLine > RoadLine.LEFT)
            {
                roadLine--;
                Status();
            }
        }
        
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(rightCollider.TriggerCheck)
            {
                return;
            }

            if(roadLine < RoadLine.RIGHT)
            {
                roadLine++;
                Status();
            }
        }
    }

    private void Status()
    {
        switch(roadLine)
        {
            case RoadLine.LEFT:
                Movement(-maxWidth);
                break;
            case RoadLine.MIDDLE:
                Movement(0);
                break;
            case RoadLine.RIGHT:
                Movement(maxWidth);
                break;
        }
    }

    private void Movement(float maxWidth)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(maxWidth,0,0), lerpspeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        CollisionObject collisionObject = other.GetComponent<CollisionObject>();

        if(collisionObject != null)
        {
            collisionObject.Activate(this);
        }
    }

    private void OnDisable()
    {
        InputManager.instance.keyAction -= Move;
    }
}
