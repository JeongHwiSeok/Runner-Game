using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float decreaseTime = 0.075f;
    public static float spawnTime = 2.5f;

    public void ControlLevel()
    {
        if(spawnTime > 0.25f)
        {
            spawnTime -= decreaseTime;
        }
    }
}
