using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : DamageSender
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

    protected override void ResetValue()
    {
        base.ResetValue();
        amount = enemyController.Character.damage;
    }
}
