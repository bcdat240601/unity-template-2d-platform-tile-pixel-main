using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNode : Node
{
    [SerializeField] protected List<Node> nodes = new List<Node>();

    protected override void GetAllChildNode()
    {
        if (nodes.Count != 0) return;
        foreach (Transform child in transform)
        {
            nodes.Add(child.GetComponent<Node>());
        }
        Debug.Log("Reset " + nameof(nodes) + " in " + GetType().Name);
    }

    public override void Init(EnemyAI enemyAI, ActionNode parent)
    {
        base.Init(enemyAI, parent);
        foreach (Node node in nodes)
        {
            node.Init(enemyAI, this);
        }
    }
    public override NodeState Evaluate()
    {
        throw new System.NotImplementedException();
    }

    public virtual T GetNode<T>() where T : Node
    {
        foreach (Node node in nodes)
        {
            T neededNode = node as T;
            if(neededNode != null)
                return neededNode;
        }
        return null;
    }

}
