using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : SetupBehaviour
{

    protected virtual void FixedUpdate()
    {
        CheckDespawn();
    }
    protected abstract bool CanBeDespawned();

    protected virtual void CheckDespawn()
    {
        if (!CanBeDespawned()) return;
        DespawnObject();
    }

    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
}