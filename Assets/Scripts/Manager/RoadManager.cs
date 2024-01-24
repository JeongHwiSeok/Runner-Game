using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> roadList;

    [SerializeField] public float offset = 24.3f;

    void Start()
    {
        roadList.Capacity = 10;
    }

    // Update is called once per frame
    void Update()
    {
        MoveRoad();
    }

    public void MoveRoad()
    {
        if (GameManager.instance.state == false)
        {
            return;
        }
        for (int i = 0; i < roadList.Count; i++)
        {
            roadList[i].transform.Translate(Vector3.back * GameManager.instance.Speed * Time.deltaTime);
        }
    }

    public void LoadRoad()
    {
        GameObject newRoad = roadList[0];
        
        roadList.Remove(newRoad);
        
        float newZ = roadList[roadList.Count - 1].transform.position.z + offset;

        newRoad.transform.position = new Vector3(0, 0, newZ);
        
        roadList.Add(newRoad);
    }
}
