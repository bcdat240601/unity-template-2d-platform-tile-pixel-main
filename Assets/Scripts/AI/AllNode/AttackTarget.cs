using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTarget : Node
{
    [SerializeField] protected EnemyController enemyController;
    [SerializeField] protected CoolDown coolDown;

    
    public override NodeState Evaluate()
    {
        nodeState = NodeState.RUNNING;
        StartNode();
        AttackingTarget();
        EndNode();
        return nodeState;
    }

    public override void Init(EnemyAI enemyAI, ActionNode parent)
    {
        base.Init(enemyAI, parent);
        enemyController = enemyAI.EnemyController;
        coolDown = parent.GetNode<CoolDown>();
    }

    protected virtual void AttackingTarget()
    {
        if (!enemyController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_3"))
            enemyController.Animator.SetTrigger("Idle");
        enemyController.Animator.SetTrigger("Attack_3");
        coolDown.timer.StartTimer();
        nodeState = NodeState.SUCCESS;
    }
}
