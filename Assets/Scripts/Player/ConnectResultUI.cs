using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectResultUI : SetupBehaviour
{
    [SerializeField] protected ResultEventChannelSO resultEventChannelSO;
    public ResultEventChannelSO ResultEventChannel => resultEventChannelSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetResultEventChannelSO();
    }

    protected virtual void GetResultEventChannelSO()
    {
        if (resultEventChannelSO != null) return;
        string resoucesPath = "Channel/ResultEventChannel";
        resultEventChannelSO = Resources.Load<ResultEventChannelSO>(resoucesPath);
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.name + " : " + nameof(resultEventChannelSO));
    }
}
