using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerAttack : PlayerAbstract
{
    [SerializeField] protected bool inputAttack;
    public bool InputAttack => inputAttack;
    [SerializeField] protected Timer timerForDelayAttack;

    protected override void Awake()
    {
        base.Awake();
        playerController.InputEventChannelSO.OnAttack += SetAttack;
    }

    protected virtual void SetAttack(bool inputAttack)
    {
        this.inputAttack = inputAttack;
    }
    protected virtual void Update()
    {
        Attack();
        //CheckBuff();
    }
    //protected virtual void CheckBuff()
    //{
    //    if (attackSpeed == 1) return;
    //    if (!timerForBuffDuration.CheckTimer()) return;
    //    attackSpeed = 1;

    //}

    protected virtual void Attack()
    {
        if (!inputAttack) return;
        if (!timerForDelayAttack.CheckTimer()) return;
        playerController.Animator.SetTrigger(PlayerAnimator.attack_1.ToString());
        timerForDelayAttack.SetCooldownTime(1f);
    }
}