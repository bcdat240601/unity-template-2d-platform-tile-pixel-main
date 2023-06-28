using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("EnemyDamageReceiver")]
    [SerializeField] protected EnemyController enemyController;
    public static event Action OnEnemyDead;
    [SerializeField] protected BuffSpawning buffSpawning;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetEnemyController();
        GetBuffSpawn();
    }

    protected virtual void GetBuffSpawn()
    {
        if (buffSpawning != null) return;
        buffSpawning = GetComponentInChildren<BuffSpawning>();
        Debug.Log("Reset " + GetType().Name + " in " + transform.parent.name + " : " + nameof(buffSpawning));
    }

    protected virtual void GetEnemyController()
    {
        if (enemyController != null) return;
        enemyController = GetComponentInParent<EnemyController>();
        Debug.Log("Reset " + GetType().Name + " in " + transform.parent.name + " : " + nameof(enemyController));
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        maxHealth = enemyController.Character.health;
        currentHealth = maxHealth;
    }
    protected override bool Reborn()
    {
        base.Reborn();
        currentHealth = maxHealth;
        return true;
    }
    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        enemyController.Animator.SetTrigger("Hurt");
    }
    protected override void OnDead()
    {
        base.OnDead();
        OnEnemyDead?.Invoke();
        enemyController.EnemyDespawn.IsDead();
        SpawnItem();
    }
    protected virtual void SpawnItem()
    {
        foreach (BuffName buffName in buffSpawning.BuffName)
        {
            ItemSpawner.Instance.Spawn(buffName.ToString(), transform.parent.position, Quaternion.identity);
        }
    }
    protected override void PushingBack()
    {
        Vector3 direction = transform.parent.position - FindObjectOfType<PlayerController>().transform.position;
        direction = direction.normalized * 1;
        transform.parent.position += direction;
    }
}
