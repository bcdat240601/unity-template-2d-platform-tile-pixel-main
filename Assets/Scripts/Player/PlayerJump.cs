using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerJump : PlayerAbstract
{
    [SerializeField] protected bool inputJump;
    [SerializeField] protected Timer timer;
    [SerializeField] protected float height = 1f;
    [SerializeField] protected float heightJump = 200f;
    [SerializeField] protected PlayerState.State playerState = PlayerState.State.Jump;
    [SerializeField] protected Collider2D groundCheck;
    public Collider2D GroundCheck => groundCheck;
    [SerializeField] protected Transform ground;
    [SerializeField] protected LayerMask layerMask;
    protected override void Awake()
    {
        base.Awake();
        playerController.InputEventChannelSO.OnJump += DetectJump;
    }
    public virtual void ResetJumpHeight()
    {
        height = 1;
        playerController.InformationEventChannelSO.RaiseUpdateJump(height);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetGround();
        GetLayerMask();
    }

    protected virtual void GetLayerMask()
    {
        layerMask = LayerMask.GetMask("Ground");
    }

    protected virtual void GetGround()
    {
        if (ground != null) return;
        ground = transform.GetChild(0).transform;
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.name + " : " + nameof(ground));
    }

    protected virtual void DetectJump(bool inputJump)
    {
        this.inputJump = inputJump;
    }
    protected virtual void Update()
    {
        CheckGround();
    }
    protected virtual void FixedUpdate()
    {
        Jump();
    }    
    protected virtual void CheckGround()
    {
        groundCheck = Physics2D.OverlapCircle(ground.position, 0.1f, layerMask);       
    }
    protected virtual void Jump()
    {
        if (!inputJump) return;
        if (groundCheck == null) return;
        if (!timer.CheckTimer()) return;
        playerController.PlayerRigidBody.velocity = new Vector2(playerController.PlayerRigidBody.velocity.x, height * heightJump * Time.fixedDeltaTime);
        playerController.Animator.SetBool(PlayerAnimator.jump_01.ToString(), true);
        timer.SetCooldownTime(1.4f);
    }
    public virtual void IncreaseJump()
    {
        height++;
        playerController.InformationEventChannelSO.RaiseUpdateJump(height);
    }
    private void OnDrawGizmos()
    {
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(ground.position, 0.1f);
        }
    }
}