using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Character", menuName = "Scriptable Objects/Character")]
public class Character : ScriptableObject
{
    public int health;
    public int damage;
}
