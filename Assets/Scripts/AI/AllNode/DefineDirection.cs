using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineDirection : Node
{
    protected int distanceToMove;
    protected EnemyAI enemyAI;
    protected Collider2D collider2D;

    public DefineDirection(EnemyAI enemyAI)
    {
        this.enemyAI = enemyAI;
    }
    public override NodeState Evaluate()
    {
        nodeState = NodeState.RUNNING;
        FindNewPosition();
        return nodeState;
    }

    protected virtual void FindNewPosition()
    {
        if (enemyAI.enemyActiveState != EnemyActiveState.Move)
        {
            nodeState = NodeState.FAILURE;
            return;
        }
        collider2D = Physics2D.OverlapCircle(enemyAI.CheckWall.position, 0.1f,enemyAI.CheckWallMask);
        if (collider2D != null || enemyAI.DistanceToMove <= 0)
        {
            enemyAI.DistanceToMove = Random.Range(3, 7);
            ChangeDirection();
        }
        enemyAI.DistanceToMove -= Time.deltaTime;
        nodeState = NodeState.SUCCESS;       
    }    
    protected virtual void ChangeDirection()
    {
        if (enemyAI.EnemyDirection == EnemyDirection.Left)
            enemyAI.EnemyDirection = EnemyDirection.Right;
        else
            enemyAI.EnemyDirection = EnemyDirection.Left;
    }
}
