using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : SetupBehaviour
{
    [SerializeField] protected InputEventChannelSO inputEventChannelSO;
    public InputEventChannelSO InputEventChannelSO => inputEventChannelSO;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetInputChannel();
    }
    protected virtual void GetInputChannel()
    {
        if (inputEventChannelSO != null) return;
        string resoucesPath = "Channel/InputEventChannel";
        inputEventChannelSO = Resources.Load<InputEventChannelSO>(resoucesPath);
        Debug.Log((object)("Reset " + this.GetType().Name + " in " + transform.name + " : " + nameof(inputEventChannelSO)));
    }
    public void OnAttack(InputAction.CallbackContext context)
    {        
        if (context.started) return;
        bool value = context.ReadValueAsButton();
        inputEventChannelSO.RaiseAttack(value);
    }
    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started) return;
        bool value = context.ReadValueAsButton();
        inputEventChannelSO.RaiseSprint(value);
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        float inputVector = context.ReadValue<float>();
        inputEventChannelSO.RaiseMove(inputVector);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started) return;
        bool value = context.ReadValueAsButton();
        inputEventChannelSO.RaiseJump(value);
    }
}