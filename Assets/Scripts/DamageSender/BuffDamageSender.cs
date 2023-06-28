using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDamageSender : DamageSender
{
    [SerializeField] protected BuffController buffController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetBuffController();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        amount = 1;
    }

    protected virtual void GetBuffController()
    {
        if (buffController != null) return;
        buffController = GetComponentInParent<BuffController>();
        Debug.Log("Reset " + nameof(buffController) + " in " + GetType().Name);
    }

    public override void SendDamage(Transform gameObject)
    {
        IBuffReceiver buffObject = gameObject.GetComponent<IBuffReceiver>();
        if (buffObject == null) return;
        SendDamage(buffObject);
    }
    protected virtual void SendDamage(IBuffReceiver damageableObject)
    {
        damageableObject.ReceiveBuff(amount, buffController.BuffType);
        Destroy(transform.parent.gameObject);
    }
}