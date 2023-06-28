using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByLostConnect : Despawn
{
    [SerializeField] protected bool isConnecting;

    protected virtual void OnEnable()
    {
        isConnecting = true;
    }

    protected override bool CanBeDespawned()
    {
        return !isConnecting;
    }

    public virtual void IsLostConnect()
    {
        isConnecting = false;
    }
}
