using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New buff",menuName = "Buffs/GodBuff")]
public class GodBuff : ScriptableObject
{
    public new string name;
    public PlayerBuffHolder.BuffName buffName;
    public float duration;
    public float speed;
    public float attackSpeed;
    public float shield;
    public float forceAttack;
    public float knockbackProtection;
    public float attackDamage;
}
