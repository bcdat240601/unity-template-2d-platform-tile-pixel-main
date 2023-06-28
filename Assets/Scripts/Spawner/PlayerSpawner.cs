using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : Spawner
{
    protected static PlayerSpawner instance;
    public static PlayerSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null)
        {
            Destroy(this.gameObject);
            Debug.LogError("there's 2 PlayerSpawner in the scene");
        }
        instance = this;
        ResultUI.OnReplay += DespawnAllPrefabs;
    }
}
