using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EnemyController : SetupBehaviour
{
    [SerializeField] protected EnemyDamageSender enemyDamageSender;
    public EnemyDamageSender EnemyDamageSender => enemyDamageSender;
    [SerializeField] protected Rigidbody2D enemyRigidBody;
    public Rigidbody2D EnemyRigidBody => enemyRigidBody;
    [SerializeField] protected Character character;
    public Character Character => character;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    [SerializeField] protected EnemyDamageReceiver damageReceiver;
    public EnemyDamageReceiver DamageReceiver => damageReceiver;
    [SerializeField] protected EnemyDetectTarget enemyDetectTarget;
    public EnemyDetectTarget EnemyDetectTarget => enemyDetectTarget;
    [SerializeField] protected EnemyAI enemyAI;
    public EnemyAI EnemyAI => enemyAI;
    [SerializeField] protected EnemyDespawn enemyDespawn;
    public EnemyDespawn EnemyDespawn => enemyDespawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetEnemyDamageSender();
        GetEnemyRigidBody();
        GetAnimator();
        GetDamageReceiver();
        GetEnemyDetectTarget();
        GetEnemyAI();
        GetEnemyDespawn();
        GetEnemyInformation();
    }

    private void GetEnemyDespawn()
    {
        if (enemyDespawn != null) return;
        enemyDespawn = GetComponentInChildren<EnemyDespawn>();
        Debug.Log("Reset " + nameof(enemyDespawn) + " in " + GetType().Name);
    }
    protected virtual void GetEnemyAI()
    {
        if (enemyAI != null) return;
        enemyAI = GetComponentInChildren<EnemyAI>();
        Debug.Log("Reset " + nameof(enemyAI) + " in " + GetType().Name);
    }

    protected virtual void GetEnemyDetectTarget()
    {
        if (enemyDetectTarget != null) return;
        enemyDetectTarget = GetComponentInChildren<EnemyDetectTarget>();
        Debug.Log("Reset " + nameof(enemyDetectTarget) + " in " + GetType().Name);
    }

    protected virtual void GetEnemyDamageSender()
    {
        if (enemyDamageSender != null) return;
        enemyDamageSender = GetComponentInChildren<EnemyDamageSender>();
        Debug.Log("Reset " + nameof(enemyDamageSender) + " in " + GetType().Name);
    }
    protected virtual void GetEnemyRigidBody()
    {
        if (enemyRigidBody != null) return;
        enemyRigidBody = GetComponent<Rigidbody2D>();
        Debug.Log("Reset " + nameof(enemyRigidBody) + " in " + GetType().Name);
    }
    
    protected virtual void GetAnimator()
    {
        if (animator != null) return;
        animator = GetComponentInChildren<Animator>();
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.name + " : " + nameof(animator));
    }
    protected virtual void GetDamageReceiver()
    {
        if (damageReceiver != null) return;
        damageReceiver = GetComponentInChildren<EnemyDamageReceiver>();
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.name + " : " + nameof(damageReceiver));
    }
    protected virtual void GetEnemyInformation()
    {
        if (character != null) return;
        string resoucesPath = "Enemy/" + transform.name;
        character = Resources.Load<Character>(resoucesPath);
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.name + " : " + nameof(character));
    }
}
