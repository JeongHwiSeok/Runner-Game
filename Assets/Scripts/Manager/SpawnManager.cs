using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPosition;

    [SerializeField] List<GameObject> vehicleList;

    [SerializeField] List<GameObject> standbyvehicleLsit;

    [SerializeField] int maxcount;
    private int random;
    private int randomCount;

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
            GameObject vehicle = Instantiate(vehicleList[Random.Range(0, vehicleList.Count)]);

            vehicle.SetActive(false);

            standbyvehicleLsit.Add(vehicle);
        }
    }

    IEnumerator ActiveVehicle()
    {
        while(true)
        {
            // Vehicle의 생성 수를 1~2를 랜덤으로 정함
            randomCount = Random.Range(1, 3);

            // 각 위치에 따른 Vehicle의 존재유무를 체크하기 위한 bool배열
            bool[] spawnPositionCheck = new bool[3];

            // randomCount에 따른 차량의 생성 함수
            for(int i = 0; i < randomCount; i++)
            {
                // vehicleList에서 임의의 vehicle을 정하기 위한 random변수 
                random = Random.Range(0, standbyvehicleLsit.Count);

                // 저장되어 있는 standbyvehicleList에서 standbyvehicleList[random]이 활성화 되있는지 체크하는 함수
                while (standbyvehicleLsit[random].activeSelf)
                {
                    // standbyvehicleList의 전체 활성화 체크 함수
                    if(ListCheck())
                    {
                        // 전부 활성화 되어 있다면 다시 vehicle 생성
                        Create();
                    }
                    // 만약 standbyvehicleList[random]이 활성화 되어 있다면 random을 다시 생성
                    random = (random + 1) % standbyvehicleLsit.Count;
                }

                // standbyvehicleList[random]이 비활성화 상태라면 활성화
                standbyvehicleLsit[random].SetActive(true);

                // 생성할 위치를 임의의 랜덤을 뽑는 함수
                int positionNumber = Random.Range(0, 3);

                // 임의의 위치에 활성화 된 vehicle이 있는지 체크
                while(spawnPositionCheck[positionNumber])
                {
                    // 임의의 위치에 vehicle이 활성화 되어 있다면 다시 랜덤 위치를 생성
                    positionNumber = (positionNumber + 1) % 3;
                }

                // 임의의 위치에 활성화 된 vehicle이 없다면 지정된 위치에 vehicle을 활성화
                standbyvehicleLsit[random].transform.position = spawnPosition[positionNumber].transform.position;
                
                // 임의의 위치에 생성되었으므로 bool 배열에 생성했다고 표시
                spawnPositionCheck[positionNumber] = true;
            }

            yield return new WaitForSeconds(1);
        }
    }

    private bool ListCheck()
    {
        int i = 0;

        while(standbyvehicleLsit[i].activeSelf)
        {
            i++;
            if(i >= standbyvehicleLsit.Count)
            {
                return true;
            }
        }
        return false;
    }
}
