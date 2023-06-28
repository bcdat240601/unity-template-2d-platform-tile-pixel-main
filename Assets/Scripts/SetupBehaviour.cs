using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        LoadComponents();
        ResetValue();
    }

    protected virtual void Awake()
    {
        LoadComponents();
        ResetValue();
    }

    protected virtual void LoadComponents()
    {
        // do something
    }

    protected virtual void ResetValue()
    {
        // do something
    }

}