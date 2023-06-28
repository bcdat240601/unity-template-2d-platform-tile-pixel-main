using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerManager : SetupBehaviour
{
    [SerializeField] protected GameObject playerSpawnPosition;
    [SerializeField] protected CinemachineVirtualCamera cinemachineVirtualCamera;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetPlayerSpawnPosition();
        GetCinemachine();
    }

    protected virtual void GetCinemachine()
    {
        if (cinemachineVirtualCamera != null) return;
        cinemachineVirtualCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        Debug.Log("Reset " + nameof(cinemachineVirtualCamera) + " in " + GetType().Name);
    }

    protected override void Awake()
    {
        base.Awake();
        ResultUI.OnReplay += SpawnPlayer;
        SpawnPlayer();
    }

    protected virtual void SpawnPlayer()
    {
        Transform player = PlayerSpawner.Instance.Spawn("WoodyGuy", playerSpawnPosition.transform.position, Quaternion.identity);
        cinemachineVirtualCamera.Follow = player;
    }

    protected virtual void GetPlayerSpawnPosition()
    {
        if (playerSpawnPosition != null) return;
        playerSpawnPosition = GameObject.FindGameObjectWithTag("PlayerSpawnPosition");
        Debug.Log("Reset " + nameof(playerSpawnPosition) + " in " + GetType().Name);
    }
}
