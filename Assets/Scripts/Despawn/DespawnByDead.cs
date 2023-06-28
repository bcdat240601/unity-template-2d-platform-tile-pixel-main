using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDead : Despawn
{
    [SerializeField] protected bool isDead;

    protected virtual void OnEnable()
    {
        isDead = false;
    }

    protected override bool CanBeDespawned()
    {
        return isDead;
    }

    public virtual void IsDead()
    {
        isDead = true;
    }
}