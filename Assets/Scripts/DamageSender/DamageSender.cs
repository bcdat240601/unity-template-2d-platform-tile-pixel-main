using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageSender : SetupBehaviour
{
    [SerializeField] protected int amount;
    public virtual void SendDamage(Transform gameObject)
    {
        IDamageable damageableObject = gameObject.GetComponent<IDamageable>();
        if (damageableObject == null) return;
        SendDamage(damageableObject);
    }
    protected virtual void SendDamage(IDamageable damageableObject)
    {
        damageableObject.TakeDamage(amount);
    }
}