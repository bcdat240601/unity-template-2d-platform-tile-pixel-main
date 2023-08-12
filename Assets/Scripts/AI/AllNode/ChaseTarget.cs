using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseTarget : Node
{
    [SerializeField] protected EnemyAI enemyAI;
    [SerializeField] protected EnemyController enemyController;

    public override void Init(EnemyAI enemyAI, ActionNode parent)
    {
        base.Init(enemyAI, parent);
        this.enemyAI = enemyAI;
        enemyController = enemyAI.EnemyController;
    }
    public override NodeState Evaluate()
    {
        nodeState = NodeState.RUNNING;
        StartNode();
        ChasingTarget();
        EndNode();
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
