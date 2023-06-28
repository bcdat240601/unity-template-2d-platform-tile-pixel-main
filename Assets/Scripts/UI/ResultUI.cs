using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEditor.PackageManager;

public enum Result
{
    Victory,
    Defeated
}
public class ResultUI : SetupBehaviour
{
    [SerializeField] protected TextMeshProUGUI resultText;
    [SerializeField] protected ResultEventChannelSO resultEventChannelSO;
    [SerializeField] protected Transform result;
    public static event Action OnReplay;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetResultText();
        GetResultEventChannel();
        GetResult();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        result.gameObject.SetActive(false);
    }


    protected override void Awake()
    {
        base.Awake();
        resultEventChannelSO.OnUpdateResult += SetResult;
    }
    protected virtual void GetResultEventChannel()
    {
        if (resultEventChannelSO != null) return;
        string resoucesPath = "Channel/ResultEventChannel";
        resultEventChannelSO = Resources.Load<ResultEventChannelSO>(resoucesPath);
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.name + " : " + nameof(resultEventChannelSO));
    }

    protected virtual void GetResultText()
    {
        if (resultText != null) return;
        resultText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log("Reset " + nameof(resultText) + " in " + GetType().Name);
    }
    protected virtual void GetResult()
    {
        if (result != null) return;
        result = transform.Find("Result").transform;
        Debug.Log("Reset " + nameof(resultText) + " in " + GetType().Name);
    }
    protected virtual void SetResult(Result result)
    {
        resultText.text = result.ToString();
        this.result.gameObject.SetActive(true);

    }
    public virtual void ClickReplay()
    {
        OnReplay?.Invoke();
        result.gameObject.SetActive(false);
    }
}
