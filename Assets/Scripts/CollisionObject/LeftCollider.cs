using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCollider : MonoBehaviour
{
    private bool triggerCheck = false;

    public bool TriggerCheck
    {
        get { return triggerCheck; }
    }

    private void OnTriggerStay(Collider other)
    {
        Vehicle vehicle = other.GetComponent<Vehicle>();

        if (vehicle != null)
        {
            triggerCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Vehicle vehicle = other.GetComponent<Vehicle>();

        if (vehicle != null)
        {
            triggerCheck = false;
        }
    }
}
