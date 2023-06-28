using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarDespawn : DespawnByLostConnect
{
    protected override void DespawnObject()
    {
        HealthBarSpawner.Instance.Despawn(transform.parent);
    }
}
