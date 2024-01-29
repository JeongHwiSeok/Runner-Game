using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleDetecter : CollisionObject
{
    public override void Activate(Runner runner)
    {
        runner.RevertPosition();
    }
}
