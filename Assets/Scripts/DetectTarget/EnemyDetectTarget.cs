using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EnemyDetectTarget : DetectTargetByOverlap
{
    [SerializeField] protected EnemyController enemyController;
    [SerializeField] protected Timer timer;
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
    protected override void BeginSendingDamage(Transform target)
    {
        enemyController.EnemyDamageSender.SendDamage(target);
    }
    protected override void SetTargetMask()
    {
        targetMask = LayerMask.GetMask("Player");
    }

    protected virtual void GetPlayerController()
    {
        if (enemyController != null) return;
        enemyController = GetComponentInParent<EnemyController>();
        Debug.Log("Reset " + GetType().Name + " in " + transform.parent.name + " : " + nameof(enemyController));
    }

    protected override void GetHitBox()
    {
        if (hitBox.Length != 0) return;
        hitBox = GetComponentsInChildren<BoxCollider2D>();
        Debug.Log("Reset " + GetType().Name + " in " + transform.parent.name + " : " + nameof(hitBox));
    }
}
