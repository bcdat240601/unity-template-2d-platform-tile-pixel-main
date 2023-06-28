using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerAbstract
{
    [SerializeField] protected float speed = 500f;
    [SerializeField] protected float moveValue;
    public float MoveValue => moveValue;
    [SerializeField] protected bool isRunning;
    protected virtual void FixedUpdate()
    {
        Moving();
    }
    protected override void Awake()
    {
        base.Awake();
        playerController.InputEventChannelSO.OnMove += SetMoveValue;
        playerController.InputEventChannelSO.OnSprint += SetSprint;
    }

    protected virtual void SetMoveValue(float value)
    {
        moveValue = value;
        if (moveValue != 0 && isRunning)
            moveValue *= 2f;
    }
    protected virtual void SetSprint(bool sprint)
    {
        isRunning = sprint;
        if(moveValue != 0)
        {
            if (isRunning)
                moveValue *= 2f;
            else
                moveValue /= 2f;
        }        

    }
    // Remove velocity when changing to Attack State
    protected virtual void OnDisable()
    {
        playerController.PlayerRigidBody.velocity = Vector2.zero;
    }
    protected virtual void Moving()
    {
        PlayerFacing();
        SetAnimation();
        playerController.PlayerRigidBody.velocity = new Vector2(moveValue * speed * Time.fixedDeltaTime, playerController.PlayerRigidBody.velocity.y);
    }
    protected virtual void SetAnimation()
    {
        if (playerController.PlayerAttack.InputAttack) return;        
        playerController.Animator.SetFloat(PlayerAnimator.walk.ToString(), MagnitudeMoveValue());
    }
    protected virtual void PlayerFacing()
    {
        if (moveValue == 0) return;
        if (moveValue > 0)
            transform.parent.rotation = Quaternion.Euler(Vector3.zero);
        else
            transform.parent.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }
    protected virtual float MagnitudeMoveValue()
    {
        if (moveValue > 0)
            return moveValue;
        return moveValue * -1;
    }
}
