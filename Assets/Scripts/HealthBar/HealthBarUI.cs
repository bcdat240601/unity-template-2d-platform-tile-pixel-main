using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : SetupBehaviour
{
    [SerializeField] protected float maxHealthBarScale = 1f;
    [SerializeField] protected Transform bar;
    public Transform Bar => bar;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetBar();
    }
    protected virtual void GetBar()
    {
        if (bar != null) return;
        bar = transform.Find("Bar");
        Debug.Log("Reset " + GetType().Name + " in " + transform.name + " : " + nameof(bar));
    }
    public virtual void UpdateHealthBarUI(float currentHealth, float maxHealth)
    {
        bar.localScale = new Vector3((currentHealth * maxHealthBarScale) / maxHealth, bar.localScale.y, 0);
    }
}