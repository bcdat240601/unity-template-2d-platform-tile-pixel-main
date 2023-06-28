using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Playables;

public enum PlayerAnimator
{
    walk,
    idle,
    sneer,
    hurt,
    dead,
    attack_1,
    jump_01,
    jump_02,
    jump_03,    
}
public class PlayerController : SetupBehaviour
{
    [SerializeField] protected InputEventChannelSO inputEventChannelSO;
    public InputEventChannelSO InputEventChannelSO => inputEventChannelSO;
    [SerializeField] protected InformationEventChannelSO informationEventChannelSO;
    public InformationEventChannelSO InformationEventChannelSO => informationEventChannelSO;
    [SerializeField] protected Character character;
    public Character Character => character;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    [SerializeField] protected Rigidbody2D playerRigidBody;
    public Rigidbody2D PlayerRigidBody => playerRigidBody;
    [SerializeField] protected PlayerAttack playerAttack;
    public PlayerAttack PlayerAttack => playerAttack;
    [SerializeField] protected PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement => playerMovement;
    [SerializeField] protected PlayerDetectTarget playerDetectTarget;
    public PlayerDetectTarget PlayerDetectTarget => playerDetectTarget;
    [SerializeField] protected PlayerDamageSender playerDamageSender;
    public PlayerDamageSender PlayerDamageSender => playerDamageSender;
    [SerializeField] protected PlayerState playerState;
    public PlayerState PlayerState => playerState;
    [SerializeField] protected ConnectResultUI connectResultUI;
    public ConnectResultUI ConnectResultUI => connectResultUI;
    [SerializeField] protected PlayerJump playerJump;
    public PlayerJump PlayerJump => playerJump;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetInputChannel();
        GetPlayerAttack();
        GetPlayerMovement();
        GetPlayerDetectTarget();
        GetPlayerDamageSender();
        GetPlayerState();
        GetPlayerJump();
        GetAnimator();
        GetRigidBody();
        GetConnectResultUI();
        GetInformationChannel();
        GetPlayerInformation();
    }

    protected virtual void GetConnectResultUI()
    {
        if (connectResultUI != null) return;
        connectResultUI = GetComponentInChildren<ConnectResultUI>();
        Debug.Log("Reset " + nameof(connectResultUI) + " in " + GetType().Name);
    }

    protected virtual void GetPlayerJump()
    {
        if (playerJump != null) return;
        playerJump = GetComponentInChildren<PlayerJump>();
        Debug.Log("Reset " + nameof(playerJump) + " in " + GetType().Name);
    }

    protected virtual void GetPlayerState()
    {
        if (playerState != null) return;
        playerState = GetComponentInChildren<PlayerState>();
        Debug.Log("Reset " + nameof(playerState) + " in " + GetType().Name);
    }

    protected virtual void GetPlayerDamageSender()
    {
        if (playerDamageSender != null) return;
        playerDamageSender = GetComponentInChildren<PlayerDamageSender>();
        Debug.Log("Reset " + nameof(playerDamageSender) + " in " + GetType().Name);
    }

    protected virtual void GetPlayerDetectTarget()
    {
        if (playerDetectTarget != null) return;
        playerDetectTarget = GetComponentInChildren<PlayerDetectTarget>();
        Debug.Log("Reset " + nameof(playerDetectTarget) + " in " + GetType().Name);
    }

    protected virtual void GetPlayerAttack()
    {
        if (playerAttack != null) return;
        playerAttack = GetComponentInChildren<PlayerAttack>();
        Debug.Log("Reset " + nameof(playerAttack) + " in " + GetType().Name);
    }
    protected virtual void GetPlayerMovement()
    {
        if (playerMovement != null) return;
        playerMovement = GetComponentInChildren<PlayerMovement>();
        Debug.Log("Reset " + nameof(playerMovement) + " in " + GetType().Name);
    }

    protected virtual void GetRigidBody()
    {
        if (playerRigidBody != null) return;
        playerRigidBody = GetComponent<Rigidbody2D>();
        Debug.Log("Reset " + nameof(playerRigidBody) + " in " + GetType().Name);
    }

    protected virtual void GetAnimator()
    {
        if (animator != null) return;
        animator = GetComponentInChildren<Animator>();
        Debug.Log("Reset " + nameof(animator) + " in " + GetType().Name);
    }

    protected virtual void GetInputChannel()
    {
        if (inputEventChannelSO != null) return;
        string resoucesPath = "Channel/InputEventChannel";
        inputEventChannelSO = Resources.Load<InputEventChannelSO>(resoucesPath);
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.name + " : " + nameof(inputEventChannelSO));
    }
    protected virtual void GetInformationChannel()
    {
        if (informationEventChannelSO != null) return;
        string resoucesPath = "Channel/InformationEventChannel";
        informationEventChannelSO = Resources.Load<InformationEventChannelSO>(resoucesPath);
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.name + " : " + nameof(informationEventChannelSO));
    }
    protected virtual void GetPlayerInformation()
    {
        if (character != null) return;
        string resoucesPath = "Player/" + transform.name;
        character = Resources.Load<Character>(resoucesPath);
        Debug.Log("Reset " + this.GetType().Name + " in " + transform.name + " : " + nameof(character));
    }
    protected virtual void OnEnable()
    {
        ResetStat();
    }
    protected virtual void ResetStat()
    {
        PlayerDamageSender.ResetAttack();
        playerJump.ResetJumpHeight();
    }
}