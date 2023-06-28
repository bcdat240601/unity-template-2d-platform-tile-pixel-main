using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : SetupBehaviour
{
    [SerializeField] protected HealthBarFollowTarget healthBarFollowTarget;
    public HealthBarFollowTarget HealthBarFollowTarget => healthBarFollowTarget;
    [SerializeField] protected HealthBarUI healthBarForEnemy;
    public HealthBarUI HealthBarForEnemy => healthBarForEnemy;
    [SerializeField] protected HealthBarDespawn healthBarDespawn;
    public HealthBarDespawn HealthBarDespawn => healthBarDespawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetHealthBarFollowTarget();
        GetHealthBarUI();
        GetHealthBarDespawn();
    }

    protected virtual void GetHealthBarDespawn()
    {
        if (healthBarDespawn != null) return;
        healthBarDespawn = GetComponentInChildren<HealthBarDespawn>();
        Debug.Log("Reset " + GetType().Name + " in " + transform.name + " : " + nameof(healthBarDespawn));
    }

    protected virtual void GetHealthBarFollowTarget()
    {
        if (healthBarFollowTarget != null) return;
        healthBarFollowTarget = GetComponentInChildren<HealthBarFollowTarget>();
        Debug.Log("Reset " + GetType().Name + " in " + transform.name + " : " + nameof(healthBarFollowTarget));
    }


    protected virtual void GetHealthBarUI()
    {
        if (healthBarForEnemy != null) return;
        healthBarForEnemy = GetComponentInChildren<HealthBarUI>();
        Debug.Log("Reset " + GetType().Name + " in " + transform.name + " : " + nameof(healthBarForEnemy));
    }
}