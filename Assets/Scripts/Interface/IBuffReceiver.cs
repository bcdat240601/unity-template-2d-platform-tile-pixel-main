using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuffReceiver
{
    public void ReceiveBuff(int amount, BuffType buffType);
}
public enum BuffType
{
    Healing,
    JumpBoost,
    AttackBoost
}
