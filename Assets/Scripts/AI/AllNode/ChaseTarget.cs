using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseTarget : Node
{
    protected EnemyAI enemyAI;
    protected EnemyController enemyController;
    public ChaseTarget(EnemyAI enemyAI, EnemyController enemyController)
    {
        this.enemyAI = enemyAI;
        this.enemyController = enemyController;
    }
    public override NodeState Evaluate()
    {
        nodeState = NodeState.RUNNING;
        ChasingTarget();
        return nodeState;
    }
    protected virtual void ChasingTarget()
    {
        enemyAI.EnemyFacing();
        if (Vector3.Distance(enemyAI.Target.position, enemyAI.transform.parent.position) <= enemyAI.DistanceToStop)
        {
            enemyAI.EnemyController.EnemyRigidBody.MovePosition(enemyAI.transform.position);
            nodeState = NodeState.SUCCESS;
            return;
        }
        if (!enemyController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            enemyController.Animator.SetTrigger("Idle");
            enemyController.Animator.SetTrigger("Walk");
        }
        
        if (enemyAI.EnemyDirection == EnemyDirection.Left)
            enemyController.EnemyRigidBody.MovePosition(enemyController.transform.position + Vector3.left * Time.deltaTime * 5);
        else
            enemyController.EnemyRigidBody.MovePosition(enemyController.transform.position + Vector3.right * Time.deltaTime * 5);
        nodeState = NodeState.SUCCESS;
    }
}
