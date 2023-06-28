using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InformationUI : SetupBehaviour
{
    [SerializeField] protected TextMeshProUGUI attackText;
    [SerializeField] protected TextMeshProUGUI jumpText;
    [SerializeField] protected InformationEventChannelSO informationEventChannelSO;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetJumpText();
        GetAttackText();
        GetInformationChannel();
    }
    protected override void Awake()
    {
        base.Awake();
        informationEventChannelSO.OnUpdateAttack += UpdateAttack;
        informationEventChannelSO.OnUpdateJump += UpdateJump;
    }
    protected virtual void GetInformationChannel()
    {
        if (informationEventChannelSO != null) return;
        string resoucesPath = "Channel/InformationEventChannel";
        informationEventChannelSO = Resources.Load<InformationEventChannelSO>(resoucesPath);
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.name + " : " + nameof(informationEventChannelSO));
    }

    protected virtual void GetAttackText()
    {
        if (attackText != null) return;
        attackText = transform.Find("AttackInfor").GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log("Reset " + nameof(attackText) + " in " + GetType().Name);
    }

    protected virtual void GetJumpText()
    {
        if (jumpText != null) return;
        jumpText = transform.Find("JumpInfor").GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log("Reset " + nameof(jumpText) + " in " + GetType().Name);
    }
    protected virtual void UpdateAttack(float value)
    {
        if (attackText == null) return;
        attackText.text = ": " + value;
    }
    protected virtual void UpdateJump(float value)
    {
        if (jumpText == null) return;
        jumpText.text = ": " + value;
    }
}
