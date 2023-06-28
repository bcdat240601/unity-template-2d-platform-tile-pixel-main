using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : SetupBehaviour
{
    [SerializeField] protected Transform target;
    public Transform Target { get => target; set { target = value; } }
    protected virtual void FixedUpdate()
    {
        if (IsHavingTarget())
            FollowingTarget();
        //if(Target)
    }
    protected virtual bool IsHavingTarget()
    {
        if (target == null) return false;
        return true;
    }
    protected virtual void FollowingTarget()
    {
        transform.parent.position = target.position;
    }
    public virtual void RemoveTarget()
    {
        Debug.Log("RemoveTarget");
        Target = null;
    }
}