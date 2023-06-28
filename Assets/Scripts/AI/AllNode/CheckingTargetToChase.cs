using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingTargetToChase : Node
{
    protected EnemyAI enemyAI;

    public CheckingTargetToChase(EnemyAI enemyAI)
    {
        this.enemyAI = enemyAI;
    }

    public override NodeState Evaluate()
    {
        nodeState = NodeState.RUNNING;
        CheckTarget();
        return nodeState;
    }

    protected virtual void CheckTarget()
    {
        if(enemyAI.enemyActiveState != EnemyActiveState.Move)
        {
            nodeState = NodeState.FAILURE;
            return;
        }
        Collider2D[] targetColliders = Physics2D.OverlapCircleAll(enemyAI.transform.parent.position, enemyAI.CheckingChaseRange, enemyAI.TargetMask);
        if (targetColliders.Length == 0)
        {
            nodeState = NodeState.FAILURE;
        }
        else
        {
            enemyAI.Target = targetColliders[0].transform;
            if (targetColliders[0].transform.position.x < enemyAI.transform.parent.position.x)
                enemyAI.EnemyDirection = EnemyDirection.Left;
            else
                enemyAI.EnemyDirection = EnemyDirection.Right;
            nodeState = NodeState.SUCCESS;
        }
    }    
}
