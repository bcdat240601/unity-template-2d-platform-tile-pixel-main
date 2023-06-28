using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyManager : SetupBehaviour
{
    [SerializeField] protected List<EnemySpawn> spawnPositions;
    [SerializeField] protected int numberOfEnemy;
    [SerializeField] protected ResultEventChannelSO resultEventChannelSO;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetEnemySpawnPosition();
        GetResultEventChannelSO();
    }

    protected virtual void GetResultEventChannelSO()
    {
        if (resultEventChannelSO != null) return;
        string resoucesPath = "Channel/ResultEventChannel";
        resultEventChannelSO = Resources.Load<ResultEventChannelSO>(resoucesPath);
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.name + " : " + nameof(resultEventChannelSO));
    }

    protected virtual void GetEnemySpawnPosition()
    {
        if (spawnPositions.Count != 0) return;
        EnemySpawn[] enemySpawnPosition = GameObject.FindObjectsOfType<EnemySpawn>();
        spawnPositions = new List<EnemySpawn>(enemySpawnPosition);
        Debug.Log("Reset " + nameof(spawnPositions) + " in " + GetType().Name);
    }
    protected override void Awake()
    {
        base.Awake();
        EnemyDamageReceiver.OnEnemyDead += DeductEnemy;
        ResultUI.OnReplay += SpawnEnemy;
    }

    protected virtual void DeductEnemy()
    {
        numberOfEnemy--;
    }

    protected virtual void Start()
    {
        SpawnEnemy();
    }
    protected virtual void Update()
    {
        if (numberOfEnemy == 0)
            resultEventChannelSO.RaiseUpdateResult(Result.Victory);
    }

    protected virtual void SpawnEnemy()
    {
        foreach (EnemySpawn spawnPosition  in spawnPositions)
        {
            EnemySpawner.Instance.Spawn(spawnPosition.EnemyType.ToString(), spawnPosition.transform.position, Quaternion.identity);
        }
        numberOfEnemy = spawnPositions.Count;
    }
}
