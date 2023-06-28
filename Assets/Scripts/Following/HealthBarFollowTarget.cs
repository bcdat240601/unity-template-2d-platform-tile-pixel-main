using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFollowTarget : FollowTarget
{
    [SerializeField] protected HealthBarController healthBarController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetHealthBarController();
    }

    protected virtual void GetHealthBarController()
    {
        if (healthBarController != null) return;
        healthBarController = GetComponentInParent<HealthBarController>();
        Debug.Log("Reset " + GetType().Name + " in " + transform.name + " : " + nameof(healthBarController));
    }

    protected virtual void Update()
    {
        if (target == null)
            healthBarController.HealthBarDespawn.IsLostConnect();
    }
}
