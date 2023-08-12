using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingTargetToAttack : Node
{
    [SerializeField] protected EnemyDetectTarget enemyDetectTarget;
    [SerializeField] protected EnemyAI enemyAI;
    [SerializeField] protected Collider2D[] targetColliders;

    public override void Init(EnemyAI enemyAI, ActionNode parent)
    {
        base.Init(enemyAI, parent);
        this.enemyAI = enemyAI;
        enemyDetectTarget = enemyAI.EnemyController.EnemyDetectTarget;
    }
    public override NodeState Evaluate()
    {
        nodeState = NodeState.RUNNING;
        StartNode();
        CheckTarget();
        EndNode();
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
