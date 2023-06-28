using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerState : PlayerAbstract
{
    [SerializeField] protected State currentState;

    public enum State
    {
        Idle,
        Move,
        Jump,
        Attack
    }
    [Serializable]
    public class StateEvent
    {
        public State playerState;
        public UnityEvent unityEvent;
    }

    public StateEvent[] stateEvents;
    public virtual void ChangeState(State state)
    {
        currentState = state;
        StateEvent foundEntry = Array.Find(stateEvents, x => x.playerState == state);
        if (foundEntry != null)
        {
            foundEntry.unityEvent.Invoke();
        }
    }
}