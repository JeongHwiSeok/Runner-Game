using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDetecter : CollisionObject
{
    public override void Activate(Runner runner)
    {
        runner.animator.Play("Die");
        
        GameManager.instance.GameOver();
    }
}
