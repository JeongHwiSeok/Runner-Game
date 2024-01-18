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
            // Vehicle�� ���� ���� 1~2�� �������� ����
            randomCount = Random.Range(1, 3);

            // �� ��ġ�� ���� Vehicle�� ���������� üũ�ϱ� ���� bool�迭
            bool[] spawnPositionCheck = new bool[3];

            // randomCount�� ���� ������ ���� �Լ�
            for(int i = 0; i < randomCount; i++)
            {
                // vehicleList���� ������ vehicle�� ���ϱ� ���� random���� 
                random = Random.Range(0, standbyvehicleLsit.Count);

                // ����Ǿ� �ִ� standbyvehicleList���� standbyvehicleList[random]�� Ȱ��ȭ ���ִ��� üũ�ϴ� �Լ�
                while (standbyvehicleLsit[random].activeSelf)
                {
                    // standbyvehicleList�� ��ü Ȱ��ȭ üũ �Լ�
                    if(ListCheck())
                    {
                        // ���� Ȱ��ȭ �Ǿ� �ִٸ� �ٽ� vehicle ����
                        Create();
                    }
                    // ���� standbyvehicleList[random]�� Ȱ��ȭ �Ǿ� �ִٸ� random�� �ٽ� ����
                    random = (random + 1) % standbyvehicleLsit.Count;
                }

                // standbyvehicleList[random]�� ��Ȱ��ȭ ���¶�� Ȱ��ȭ
                standbyvehicleLsit[random].SetActive(true);

                // ������ ��ġ�� ������ ������ �̴� �Լ�
                int positionNumber = Random.Range(0, 3);

                // ������ ��ġ�� Ȱ��ȭ �� vehicle�� �ִ��� üũ
                while(spawnPositionCheck[positionNumber])
                {
                    // ������ ��ġ�� vehicle�� Ȱ��ȭ �Ǿ� �ִٸ� �ٽ� ���� ��ġ�� ����
                    positionNumber = (positionNumber + 1) % 3;
                }

                // ������ ��ġ�� Ȱ��ȭ �� vehicle�� ���ٸ� ������ ��ġ�� vehicle�� Ȱ��ȭ
                standbyvehicleLsit[random].transform.position = spawnPosition[positionNumber].transform.position;
                
                // ������ ��ġ�� �����Ǿ����Ƿ� bool �迭�� �����ߴٰ� ǥ��
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
