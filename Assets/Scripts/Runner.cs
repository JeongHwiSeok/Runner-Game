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

    [SerializeField] RoadLine currentRoadLine;
    [SerializeField] RoadLine previousRoadLine;

    [SerializeField] public float maxWidth = 2.25f;

    [SerializeField] public float lerpspeed = 30f;

    private void Start()
    {
        InputManager.instance.keyAction += Move;
        currentRoadLine = RoadLine.MIDDLE;
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
            if (currentRoadLine > RoadLine.LEFT)
            {
                previousRoadLine = currentRoadLine;
                currentRoadLine--;
                Status();
            }
        }
        
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
           if(currentRoadLine < RoadLine.RIGHT)
           {
               previousRoadLine = currentRoadLine;
               currentRoadLine++;
               Status();
           }
        }
    }

    private void Status()
    {
        switch(currentRoadLine)
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

    public void RevertPosition()
    {
        currentRoadLine = previousRoadLine;
        Status();
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
