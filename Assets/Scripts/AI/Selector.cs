using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    protected List<Node> nodes = new List<Node>();

    public Selector(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    public override NodeState Evaluate()
    {
        foreach (Node node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.SUCCESS:
                    nodeState = NodeState.SUCCESS;
                    return nodeState;
                case NodeState.FAILURE:
                    continue;
                case NodeState.RUNNING:
                    nodeState = NodeState.RUNNING;
                    return nodeState;
                default:
                    continue;
            }
        }

        nodeState = NodeState.FAILURE;
        return nodeState;
    }
}