using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseAI : SetupBehaviour
{
    [SerializeField] protected EnemyController enemyController;
    public EnemyController EnemyController => enemyController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetEnemyController();
    }

    protected virtual void OnEnable()
    {
        Node root = InitializeNode();
        StartCoroutine(StartAI(root));
    }
    protected virtual Node InitializeNode()
    {
        return null;
        //for overide
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