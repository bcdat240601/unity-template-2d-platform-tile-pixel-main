using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTarget : Node
{
    protected EnemyController enemyController;
    protected CoolDown coolDown;

    public AttackTarget(EnemyController enemyController, CoolDown coolDown)
    {
        this.enemyController = enemyController;
        this.coolDown = coolDown;
    }
    public override NodeState Evaluate()
    {
        nodeState = NodeState.RUNNING;
        AttackingTarget();
        return nodeState;
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
