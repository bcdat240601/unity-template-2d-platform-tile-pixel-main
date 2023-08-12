using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : Node
{
    [SerializeField] protected EnemyController enemyController;
    [SerializeField] protected EnemyAI enemyAI;
    [SerializeField] protected int currentDirection;

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
        Patrolling();
        EndNode();
        return nodeState;
    }

    protected virtual void Patrolling()
    {
        enemyAI.EnemyFacing();
        if (!enemyController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            enemyController.Animator.SetTrigger("Idle");
            enemyController.Animator.SetTrigger("Walk");
        }
        if (enemyAI.EnemyDirection == EnemyDirection.Left)
            enemyController.EnemyRigidBody.MovePosition(enemyController.transform.position + Vector3.left * Time.deltaTime * 2);
        else
            enemyController.EnemyRigidBody.MovePosition(enemyController.transform.position + Vector3.right * Time.deltaTime * 2);
    }
}
