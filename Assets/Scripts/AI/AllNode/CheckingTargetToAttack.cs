using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingTargetToAttack : Node
{
    protected EnemyDetectTarget enemyDetectTarget;
    protected EnemyAI enemyAI;
    protected Collider2D[] targetColliders;
    public CheckingTargetToAttack(EnemyDetectTarget enemyDetectTarget, EnemyAI enemyAI)
    {
        this.enemyDetectTarget = enemyDetectTarget;
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
        targetColliders = Physics2D.OverlapCircleAll(enemyAI.transform.parent.position, enemyAI.CheckingAttackRange, enemyAI.TargetMask);

        if(targetColliders.Length == 0)
        {
            nodeState = NodeState.FAILURE;
            return;
        }
        targetColliders = enemyDetectTarget.CheckTarget();
        if (targetColliders.Length == 0)
        {
            nodeState = NodeState.RUNNING;
            return;
        }
        else
        {
            enemyAI.EnemyFacing();
            enemyAI.EnemyController.EnemyRigidBody.MovePosition(enemyAI.transform.parent.position);
            nodeState = NodeState.SUCCESS;
        }
    }

}
