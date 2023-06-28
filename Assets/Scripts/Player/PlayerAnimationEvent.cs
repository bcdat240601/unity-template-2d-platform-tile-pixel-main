using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvent : PlayerAbstract
{
    //public virtual void EndAttack()
    //{
    //    playerController.PlayerAttack.EndAttack();
    //}
    public virtual void SetShapeIndex(int shapeIndex)
    {
        playerController.PlayerDetectTarget.SetShapeIndex(shapeIndex);
    }
    public virtual void DetectTarget()
    {
        playerController.PlayerDetectTarget.DetectTarget();
    }
    public virtual void SetPlayerIdleState()
    {
        playerController.PlayerState.ChangeState(PlayerState.State.Idle);
    }
    public virtual void SetPlayerMoveState()
    {
        playerController.PlayerState.ChangeState(PlayerState.State.Move);
    }
    public virtual void SetPlayerAttackState()
    {
        playerController.PlayerState.ChangeState(PlayerState.State.Attack);
    }
    public virtual void SetPlayerJumpState()
    {
        playerController.PlayerState.ChangeState(PlayerState.State.Jump);
    }

    // Don't put the Animation Event in the first frame if animation clip is just one-frame-only and loop.
    // In that case, put animation event in the second frame.
    public virtual void MidJump()
    {
        if (playerController.PlayerRigidBody.velocity.y <= 0) return;
        if (playerController.PlayerJump.GroundCheck != null) return;
        playerController.Animator.SetBool(PlayerAnimator.jump_02.ToString(), true);

    }
    public virtual void EndJump()
    {
        if (playerController.PlayerRigidBody.velocity.y >= 0) return;
        playerController.Animator.SetBool(PlayerAnimator.jump_03.ToString(), true);
    }
    public virtual void CancelJump()
    {
        if (playerController.PlayerJump.GroundCheck == null) return;
        playerController.Animator.SetBool(PlayerAnimator.jump_03.ToString(), false);
        playerController.Animator.SetBool(PlayerAnimator.jump_02.ToString(), false);
        playerController.Animator.SetBool(PlayerAnimator.jump_01.ToString(), false);
    }
}