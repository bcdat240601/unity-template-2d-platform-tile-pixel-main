using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "new InputChannel", menuName = "Scriptable Objects/Channel/ResultChannel")]
public class ResultEventChannelSO : ScriptableObject
{
    public event Action<Result> OnUpdateResult;

    public virtual void RaiseUpdateResult(Result result)
    {
        OnUpdateResult?.Invoke(result);
    }
}
