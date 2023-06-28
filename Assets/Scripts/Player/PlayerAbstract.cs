using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : SetupBehaviour
{
    [SerializeField] protected PlayerController playerController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetPlayerController();
    }
    protected virtual void GetPlayerController()
    {
        if (playerController != null) return;
        playerController = GetComponentInParent<PlayerController>();
        Debug.Log("Reset " + nameof(playerController) + " in " + GetType().Name);
    }
}