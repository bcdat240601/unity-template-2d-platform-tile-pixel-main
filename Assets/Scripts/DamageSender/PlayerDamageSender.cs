using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSender : DamageSender
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
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.name + " : " + nameof(playerController));
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        amount = playerController.Character.damage;
    }
    public virtual void IncreaseAmount()
    {
        amount++;
        playerController.InformationEventChannelSO.RaiseUpdateAttack(amount);
    }
    public virtual void ResetAttack()
    {
        amount = 1;
        playerController.InformationEventChannelSO.RaiseUpdateAttack(amount);
    }
}
