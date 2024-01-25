using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New buff",menuName = "Buffs/KnockbackBuff")]
public class KnockbackBuff : ScriptableObject
{
    public new string name;
    public PlayerBuffHolder.BuffName buffName;
    public float duration;
    public float forceAttack;
    public float knockbackProtection;
}
