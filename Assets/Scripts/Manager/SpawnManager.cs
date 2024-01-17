using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPosition;

    [SerializeField] List<GameObject> vehicleList;

    [SerializeField] List<GameObject> standbyvehicleLsit;

    [SerializeField] int maxcount;
    private int count;
    private int random;

    private void Start()
    {
        standbyvehicleLsit.Capacity = 20;

        Create();

        StartCoroutine(ActiveVehicle());
    }

    public void Create()
    {
        for(int i = 0; i < maxcount; i++)
        {
            GameObject vehicle = Instantiate(vehicleList[Random.Range(0, vehicleList.Count)], spawnPosition[Random.Range(0, 3)]);

            vehicle.SetActive(false);

            standbyvehicleLsit.Add(vehicle);
        }
    }

    IEnumerator ActiveVehicle()
    {
        while(true)
        {
            random = Random.Range(0, standbyvehicleLsit.Count);

            while (standbyvehicleLsit[random].activeSelf == true)
            {
                count++;
                if(count >= standbyvehicleLsit.Count)
                {
                    yield break;
                }                
                random = (random + 1) % standbyvehicleLsit.Count;
            }
            standbyvehicleLsit[random].SetActive(true);
            yield return new WaitForSeconds(5);
        }
    }
}
