using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectTarget : DetectTargetByOverlap
{
    [Header("PlayerDetectTarget")]
    [SerializeField] protected PlayerController playerController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetPlayerController();
        GetHitBox();
    }
    protected override void BeginSendingDamage(Transform target)
    {
        playerController.PlayerDamageSender.SendDamage(target);
    }
    protected override void SetTargetMask()
    {
        targetMask = LayerMask.GetMask("Enemy");
    }

    protected virtual void GetPlayerController()
    {
        if (playerController != null) return;
        playerController = GetComponentInParent<PlayerController>();
        Debug.Log("Reset " + GetType().Name + " in " + transform.parent.name + " : " + nameof(playerController));
    }

    protected override void GetHitBox()
    {
        if (hitBox.Length != 0) return;
        hitBox = GetComponentsInChildren<PolygonCollider2D>();
        Debug.Log("Reset " + GetType().Name + " in " + transform.parent.name + " : " + nameof(hitBox));
    }
}