using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Sequence : Node
{
    protected List<Node> nodes = new List<Node>();

    public Sequence(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    public override NodeState Evaluate()
    {
        bool isRunning = false;
        foreach (Node node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.SUCCESS:
                    continue;
                case NodeState.FAILURE:
                    nodeState = NodeState.FAILURE;
                    return nodeState;
                case NodeState.RUNNING:
                    isRunning = true;
                    continue;
                default:
                    nodeState = NodeState.SUCCESS;
                    return nodeState;
            }
        }

        nodeState = isRunning ? NodeState.RUNNING : NodeState.SUCCESS;
        return nodeState;
    }
}