using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarSpawner : Spawner
{
    protected static HealthBarSpawner instance;
    public static HealthBarSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null)
        {
            Destroy(this.gameObject);
            Debug.LogError("there's 2 HealthBarSpawner in the scene");
        }
        instance = this;
        ResultUI.OnReplay += DespawnAllPrefabs;
    }

    protected override void DespawnAllPrefabs()
    {
        base.DespawnAllPrefabs();
        Debug.Log("DespawnallHealthbar");
    }
}
