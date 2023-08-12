using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseAI : SetupBehaviour
{
    [SerializeField] protected EnemyController enemyController;
    public EnemyController EnemyController => enemyController;
    [SerializeField] protected Node root;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetEnemyController();
        GetRoot();
    }

    protected virtual void GetRoot()
    {
        if (root != null) return;
        root = transform.Find("Root").GetComponent<Node>();
        Debug.Log("Reset " + nameof(root) + " in " + GetType().Name);

    }
    protected override void Awake()
    {
        base.Awake();
        InitializeNode();
    }
    protected virtual void OnEnable()
    {        
        StartCoroutine(StartAI(root));
    }
    protected virtual void InitializeNode()
    {
        // for override
    }
    protected virtual IEnumerator StartAI(Node root)
    {
        while (true)
        {
            if (enemyController.DamageReceiver.isDead) break;
            root.Evaluate();
            yield return new WaitForEndOfFrame();
        }
    }
    
    protected virtual void GetEnemyController()
    {
        if (enemyController != null) return;
        enemyController = GetComponentInParent<EnemyController>();
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.parent.name + " : " + nameof(enemyController));
    }
}