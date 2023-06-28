using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The enum name for ItemSpawner
public enum BuffName
{
    None,
    HealthPotion,
    AttackBoost,
    JumpBoost
}
public abstract class DamageReceiver : SetupBehaviour, IDamageable
{
    [Header("DamageReceiver")]
    [SerializeField] protected int currentHealth;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected HealthBarHolder healthBarHolder;
    [SerializeField] protected BuffName buffSpawn;
    public bool isDead;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetHealthBarHolder();
    }
    protected virtual void SetHealthBar()
    {
        Transform healthbar = HealthBarSpawner.Instance.Spawn("HealthBar", healthBarHolder.transform.position, Quaternion.identity);
        healthbar.TryGetComponent<HealthBarController>(out HealthBarController healthBarController);
        healthBarHolder.HealthBarController = healthBarController;
        healthBarHolder.HealthBarController.HealthBarFollowTarget.Target = healthBarHolder.transform;
    }
    protected virtual void UpdateHealthBar()
    {
        if (healthBarHolder.HealthBarController == null) return; 
        healthBarHolder.HealthBarController.HealthBarForEnemy.UpdateHealthBarUI(currentHealth, maxHealth);
    }

    protected virtual void GetHealthBarHolder()
    {
        if (healthBarHolder != null) return;
        healthBarHolder = GetComponentInChildren<HealthBarHolder>();
        Debug.Log("Reset " + GetType().Name + " in " + transform.name + " : " + nameof(healthBarHolder));
    }

    protected override void ResetValue()
    {
        Collider2D collider2D = GetComponent<Collider2D>();
        collider2D.isTrigger = true;
    }
    protected virtual void OnEnable()
    {               
        StartCoroutine(SetHealthBarWhenSpawning());
    }
    IEnumerator SetHealthBarWhenSpawning()
    {
        yield return new WaitUntil(Reborn);
        SetHealthBar();
        UpdateHealthBar();
    }
    protected virtual bool Reborn()
    {
        isDead = false;
        return true;
        //for override
    }
    public virtual void Healing(int amount)
    {
        currentHealth += amount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public virtual void TakeDamage(int amount)
    {
        if (isDead) return;
        currentHealth -= amount;
        //float offset = DamageSpawner.Instance.GetRandomOffsetPosition(0.5f, 1.5f);
        //DamageSpawner.Instance.Spawn("DamagePopup", transform.parent.position + Vector3.up * offset, Quaternion.identity, amount.ToString());
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDead();
        }
        UpdateHealthBar();
        PushingBack();
    }
    protected virtual void OnDead()
    {
        healthBarHolder.HealthBarController.HealthBarFollowTarget.RemoveTarget();
        healthBarHolder.HealthBarController = null;
        isDead = true;
        //for override
    }
    public virtual void TurnOffAnimationHurt()
    {
        //for override
    }

    protected virtual void PushingBack()
    {
        //for override
    }
}