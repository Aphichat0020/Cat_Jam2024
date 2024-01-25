using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public SpeedBuff speedBuff;
    public KnockbackBuff knockbackBuff;
    public GiantBuff giantBuff;
    public GodBuff godBuff;

    public PlayerBuffHolder playerBuffHolder;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            GivePlayerBuff(PlayerBuffHolder.BuffName.Speed);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            GivePlayerBuff(PlayerBuffHolder.BuffName.Knockback);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            GivePlayerBuff(PlayerBuffHolder.BuffName.Giant);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            GivePlayerBuff(PlayerBuffHolder.BuffName.God);
        }
    }
    public void GivePlayerBuff(PlayerBuffHolder.BuffName buff)
    {
        playerBuffHolder.PlayerGetBuff(buff);
    }
}
