using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : SetupBehaviour
{
    protected NodeState nodeState;
    [SerializeField] protected ActionNode parent;
    [SerializeField] protected string nodeName;
    [SerializeField] protected Timer timerForDebug;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetAllChildNode();
    }

    protected virtual void GetAllChildNode()
    {
        //to override
    }

    public virtual void Init(EnemyAI enemyAI, ActionNode parent)
    {
        nodeName = transform.name;
        this.parent = parent;
    }

    protected virtual void StartNode()
    {
        timerForDebug.SetCooldownTime(1f);
        if (transform.name != nodeName) return;
        transform.name = transform.name + " isRunning";
    }
    protected virtual void EndNode()
    {
        if (!timerForDebug.CheckTimer()) return;
        transform.name = nodeName;
    }
    public NodeState NodeState => nodeState;

    public abstract NodeState Evaluate();
}

public enum NodeState
{
    SUCCESS, FAILURE, RUNNING,
}