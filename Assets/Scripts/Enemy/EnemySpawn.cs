using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Enemy_01,
    Enemy_02,
    Boss_01,
    BossFinal
}
public class EnemySpawn : SetupBehaviour
{
    public EnemyType EnemyType;
}
