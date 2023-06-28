using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawning : SetupBehaviour
{
    [SerializeField] protected List<BuffName> buffName;
    public List<BuffName> BuffName => buffName;
}
