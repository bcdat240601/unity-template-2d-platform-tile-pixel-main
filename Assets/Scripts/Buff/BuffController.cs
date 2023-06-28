using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : SetupBehaviour
{
    [SerializeField] protected BuffDamageSender buffDamageSender;
    public BuffDamageSender BuffDamageSender => buffDamageSender;
    [SerializeField] protected BuffType buffType;
    public BuffType BuffType => buffType;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetBuffDamageSender();
    }

    protected virtual void GetBuffDamageSender()
    {
        if (buffDamageSender != null) return;
        buffDamageSender = GetComponentInChildren<BuffDamageSender>();
        Debug.Log("Reset " + nameof(buffDamageSender) + " in " + GetType().Name);
    }
}