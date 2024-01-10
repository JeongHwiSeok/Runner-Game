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
            if(roadLine >= RoadLine.MIDDLE)
            {
                roadLine--;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(roadLine <= RoadLine.MIDDLE)
            {
                roadLine++;
            }
        }
    }
}
