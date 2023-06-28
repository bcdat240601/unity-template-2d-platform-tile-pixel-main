using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDamageReceiver : DamageReceiver, IBuffReceiver
{
    [Header("PlayerDamageReceiver")]
    [SerializeField] protected PlayerController playerController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetCharacterController();
    }    
    protected override void ResetValue()
    {
        base.ResetValue();
        maxHealth = playerController.Character.health;
        currentHealth = maxHealth;
    }
    protected override bool Reborn()
    {
        base.Reborn();
        currentHealth = maxHealth;
        return true;
    }
    public override void Healing(int amount)
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
    public override void TakeDamage(int amount)
    {        
        base.TakeDamage(amount);
        playerController.Animator.SetTrigger("hurt");
    }    

    protected virtual void GetCharacterController()
    {
        if (playerController != null) return;
        playerController = GetComponentInParent<PlayerController>();
        Debug.Log("Reset " + GetType().Name + " in " + transform.parent.name + " : " + nameof(playerController));
    }
    protected override void OnDead()
    {
        base.OnDead();
        playerController.Animator.SetTrigger(PlayerAnimator.dead.ToString());        
        playerController.ConnectResultUI.ResultEventChannel.RaiseUpdateResult(Result.Defeated);
        PlayerSpawner.Instance.Despawn(transform.parent);
        Debug.Log("DeSpawnPlayer");
    }

    public void ReceiveBuff(int amount, BuffType buffType)
    {          
        switch (buffType)
        {
            case BuffType.Healing:
                Healing(amount);
                break;
            case BuffType.JumpBoost:
                playerController.PlayerJump.IncreaseJump();
                break;
            case BuffType.AttackBoost:
                playerController.PlayerDamageSender.IncreaseAmount();
                break;
            default:
                break;
        }
    }
}