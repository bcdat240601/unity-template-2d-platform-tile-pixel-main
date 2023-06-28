using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDetectTarget : DetectTargetByTriggerEnter
{
    [SerializeField] protected BuffController buffController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetBuffController();
    }

    protected virtual void GetBuffController()
    {
        if (buffController != null) return;
        buffController = GetComponentInParent<BuffController>();
        Debug.Log("Reset " + nameof(buffController) + " in " + GetType().Name);
    }
    protected override bool ConditionToDetect(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player")) return false;
        return base.ConditionToDetect(collision);
    }

    protected override void BeginSendingDamage(Transform target)
    {
        buffController.BuffDamageSender.SendDamage(target);
    }
}
