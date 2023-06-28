using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node
{
    protected NodeState nodeState;

    public NodeState NodeState => nodeState;

    public abstract NodeState Evaluate();
}

public enum NodeState
{
    SUCCESS, FAILURE, RUNNING,
}