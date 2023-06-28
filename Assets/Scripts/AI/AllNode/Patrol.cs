using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : Node
{
    protected EnemyController enemyController;
    protected EnemyAI enemyAI;
    protected int currentDirection;
    public Patrol(EnemyController enemyController, EnemyAI enemyAI)
    {        
        this.enemyController = enemyController;
        this.enemyAI = enemyAI;
    }
    public override NodeState Evaluate()
    {
        nodeState = NodeState.RUNNING;
        Patrolling();
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
