using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "new InputChannel", menuName = "Scriptable Objects/Channel/InformationChannel")]
public class InformationEventChannelSO : ScriptableObject
{
    public event Action<float> OnUpdateAttack;
    public event Action<float> OnUpdateJump;

    public virtual void RaiseUpdateAttack(float value)
    {
        OnUpdateAttack?.Invoke(value);
    }
    public virtual void RaiseUpdateJump(float value)
    {
        OnUpdateJump?.Invoke(value);
    }
}
