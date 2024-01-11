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
    [SerializeField] RoadLine roadLine;

    [SerializeField] public float maxWidth = 3.5f;

    [SerializeField] public float speed = 5f;

    private void Start()
    {
        roadLine = RoadLine.MIDDLE;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(roadLine > RoadLine.LEFT)
            {
                roadLine--;
                Status();
            }
        }
        
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
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
        transform.position = new Vector3(maxWidth, 0, 0);
    }
}
