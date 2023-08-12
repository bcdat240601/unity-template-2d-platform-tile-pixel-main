using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public enum EnemyDirection
{
    Left,
    Right
}
public enum EnemyActiveState
{
    Move,
    Attack
}
public class EnemyAI : BaseAI
{
    [Range(1f, 10f)]
    public float CheckingChaseRange = 5f;
    [Range(1f, 3f)]
    public float CheckingAttackRange = 2.5f;
    public LayerMask TargetMask;
    public LayerMask CheckWallMask;
    [SerializeField] protected Transform checkWall;
    public Transform CheckWall => checkWall;
    public EnemyDirection EnemyDirection;
    public float DistanceToMove;
    [SerializeField] protected float distanceToStop = 2f;
    public float DistanceToStop => distanceToStop;
    public Transform Target;
    public EnemyActiveState enemyActiveState;

    #region SetupComponent
    protected override void LoadComponents()
    {
        base.LoadComponents();
        SetDefaultTargetToChase();
        GetCheckWall();
        SetCheckWallMask();
    }

    protected virtual void GetCheckWall()
    {
        if (checkWall != null) return;
        checkWall = transform.Find("CheckWall").transform;
        Debug.Log("Reset " + nameof(checkWall) + " in " + GetType().Name);
    }
    


    protected virtual void SetDefaultTargetToChase()
    {
        if (TargetMask == LayerMask.GetMask("Player")) return;
        TargetMask = LayerMask.GetMask("Player");
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.parent.name + " : " + nameof(TargetMask));
    }
    protected virtual void SetCheckWallMask()
    {
        if (CheckWallMask == LayerMask.GetMask("Ground")) return;
        CheckWallMask = LayerMask.GetMask("Ground");
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.parent.name + " : " + nameof(CheckWallMask));
    }
    #endregion


    protected override void InitializeNode()
    {
        root.Init(this, null);
    }
    public virtual void EnemyFacing()
    {
        if (EnemyDirection == EnemyDirection.Left)
        {
            transform.parent.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.parent.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.parent.position, CheckingAttackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.parent.position, CheckingChaseRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.parent.position, distanceToStop);
    }
}