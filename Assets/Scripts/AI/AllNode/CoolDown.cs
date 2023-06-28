using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoolDown : Node
{
    public Timer timer;
    public CoolDown(float timeToCooldown)
    {
        timer = new Timer();
        timer.SetCooldownTime(timeToCooldown);
    }
    public override NodeState Evaluate()
    {
        nodeState = NodeState.RUNNING;
        CheckCooldown();
        return nodeState;
    }

    protected virtual void CheckCooldown()
    {
        if (timer.CheckTimer())
        {
            nodeState = NodeState.SUCCESS;
        }
        else
        {
            nodeState = NodeState.FAILURE;
        }
    }
}