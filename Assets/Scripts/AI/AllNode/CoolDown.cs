using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoolDown : Node
{
    [SerializeField] protected float timeToCooldown;
    public Timer timer;

    public override void Init(EnemyAI enemyAI, ActionNode parent)
    {
        base.Init(enemyAI, parent);
        timer = new Timer();
        timer.SetCooldownTime(timeToCooldown);
    }
    public override NodeState Evaluate()
    {
        nodeState = NodeState.RUNNING;
        StartNode();
        CheckCooldown();
        EndNode();
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