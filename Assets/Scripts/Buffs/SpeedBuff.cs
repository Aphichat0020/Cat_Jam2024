using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New buff",menuName = "Buffs/MovementBuff")]
public class SpeedBuff : ScriptableObject
{
    public new string name;
    public PlayerBuffHolder.BuffName buffName;
    public float duration;
    public float speed;
    public float attackSpeed;
    public float knockbackProtection;
}
