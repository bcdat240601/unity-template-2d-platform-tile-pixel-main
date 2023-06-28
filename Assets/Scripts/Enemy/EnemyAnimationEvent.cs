using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvent : SetupBehaviour
{
    [SerializeField] protected EnemyController enemyController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetEnemyController();
    }

    protected virtual void GetEnemyController()
    {
        if (enemyController != null) return;
        enemyController = GetComponentInParent<EnemyController>();
        Debug.Log("Reset " + nameof(enemyController) + " in " + GetType().Name);
    }
    public virtual void EnemyDetectTarget()
    {
        enemyController.EnemyDetectTarget.DetectTarget();
    }
    public virtual void ChangeToAttackState()
    {
        enemyController.EnemyAI.enemyActiveState = EnemyActiveState.Attack;
    }
    public virtual void ChangeToMoveState()
    {
        enemyController.EnemyAI.enemyActiveState = EnemyActiveState.Move;
    }
}
