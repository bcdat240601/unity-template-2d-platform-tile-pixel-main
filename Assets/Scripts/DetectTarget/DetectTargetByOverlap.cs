using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTargetByOverlap : DetectTarget
{
    [Header("DetectTargetByOverlap")]
    [SerializeField] protected LayerMask targetMask;
    [SerializeField] protected Collider2D[] hitBox;
    [SerializeField] protected List<Collider2D> colliderList;
    [SerializeField] protected ContactFilter2D contactFilter2D;
    [SerializeField] protected int shapeIndex = 0;
    public int ShapeIndex => shapeIndex;

    protected virtual void OnEnable()
    {
        SetContactFilter();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        SetTargetMask();
        SetContactFilter();
        GetHitBox();
    }
    public virtual void SetShapeIndex(int shapeIndex)
    {
        this.shapeIndex = shapeIndex;
    }
    public virtual Collider2D[] CheckTarget()
    {
        Physics2D.OverlapCollider(hitBox[shapeIndex], contactFilter2D, colliderList);
        Collider2D[] resultList = colliderList.ToArray();
        return resultList;
    }
    //this function will be called from animation event in attack animation
    public virtual void DetectTarget()
    {
        Collider2D[] targetColliders = CheckTarget();
        foreach (Collider2D target in targetColliders)
        {
            BeginSendingDamage(target.transform);
        }
    }
    protected virtual void SetTargetMask()
    {
        //for override
    }

    protected virtual void GetHitBox()
    {
        // for override
    }
    protected virtual void SetContactFilter()
    {
        colliderList = new List<Collider2D>();
        contactFilter2D = new ContactFilter2D();
        contactFilter2D.SetLayerMask(targetMask);
        contactFilter2D.useLayerMask = true;
        contactFilter2D.useTriggers = true;
    }
}