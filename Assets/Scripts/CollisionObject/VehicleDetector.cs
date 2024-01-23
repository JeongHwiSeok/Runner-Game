using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDetector : MonoBehaviour
{
    [SerializeField] Vehicle mainVehicle;

    private void OnTriggerEnter(Collider other)
    {
        mainVehicle = transform.GetComponentInParent<Vehicle>();

        Vehicle otherVehicle = other.GetComponent<Vehicle>();

        if(otherVehicle != null)
        {
            otherVehicle.Speed = mainVehicle.Speed;
        }
    }
}
