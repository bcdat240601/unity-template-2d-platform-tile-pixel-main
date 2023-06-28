using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    protected static ItemSpawner instance;
    public static ItemSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null)
        {
            Destroy(this.gameObject);
            Debug.LogError("there's 2 ItemSpawner in the scene");
        }
        instance = this;

        ResultUI.OnReplay += DespawnAllPrefabs;
    }
}
