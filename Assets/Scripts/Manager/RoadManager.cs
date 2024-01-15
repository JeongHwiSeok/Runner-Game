using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> roadList;

    [SerializeField] public float roadSpeed = 5f;

    void Start()
    {
        roadList.Capacity = 10;
    }

    // Update is called once per frame
    void Update()
    {
        MoveRoad();
    }

    private void MoveRoad()
    {
        for (int i = 0; i < roadList.Count; i++)
        {
            roadList[i].transform.Translate(Vector3.back * roadSpeed * Time.deltaTime);
        }
    }

    public void LoadRoad()
    {
        GameObject newRoad = roadList[0];
        roadList.Remove(roadList[0]);
        float newZ = roadList[3].transform.position.z + 25f;
        newRoad.transform.position = new Vector3(0, 0, newZ);
        roadList.Add(newRoad);

        for(int i = 1; i < roadList.Count; i++ )
        {
            roadList[i - 1] = roadList[i];
        }
    }
}
