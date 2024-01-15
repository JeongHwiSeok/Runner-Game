using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Action keyAction;

    // Update is called once per frame
    void Update()
    {
        // Input.anyKey : 임의의 키 입력
        if (Input.anyKey == false)
        {
            return;
        }

        if(keyAction != null)
        {
            keyAction.Invoke();
        }
    }
}
