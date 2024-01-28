using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBuffHolder : MonoBehaviour
{
    public EnemyAI enemyAi;
    [Header("Buffs")]
    public float duration;
    public PlayerBuffHolder.BuffName curretBuff;

    public SpeedBuff speedBuff;
    public KnockbackBuff knockbackBuff;
    public GiantBuff giantBuff;
    public GodBuff godBuff;
    public bool hasBuff;
    bool checkReset;

    public GameObject normalCat;
    public Animator normalCatAnimator;
    [Header("KnockBack")]
    public GameObject StrongCat;
    public Animator StrongCatAnimator;
    [Header("Speed")]
    public GameObject SpeedCat;
    public Animator SpeedCatAnimator;
    [Header("Fat")]
    public GameObject FatCat;
    public Animator FatCatAnimator;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (curretBuff != PlayerBuffHolder.BuffName.None)
        {
            duration -= Time.deltaTime;
        }

        if (duration <= 0)
        {
            curretBuff = PlayerBuffHolder.BuffName.None;
            duration = 0;
            if (!checkReset)
            {
                EnemyBuffReset();
                checkReset = true;
            }
        }
    }

    public void EnemyGetBuff(PlayerBuffHolder.BuffName _buff)
    {
        
        switch (_buff)
        {

            case PlayerBuffHolder.BuffName.None:

                break;

            case PlayerBuffHolder.BuffName.Speed:
                EnemyBuffReset();
                curretBuff = PlayerBuffHolder.BuffName.Speed;
                enemyAi.speedBuff = speedBuff.speed;
                enemyAi.attackSpeedBuff = speedBuff.attackSpeed;
                duration = speedBuff.duration;
                enemyAi.damageBuff = speedBuff.attackDamage;

                enemyAi.anim = SpeedCatAnimator;
                normalCat.SetActive(false);
                SpeedCat.SetActive(true);

                break;
            case PlayerBuffHolder.BuffName.Knockback:
                EnemyBuffReset();
                curretBuff = PlayerBuffHolder.BuffName.Knockback;
                enemyAi.knockbackBuff = knockbackBuff.forceAttack;
                enemyAi.knockbackProtectionBuff = knockbackBuff.knockbackProtection;
                duration = knockbackBuff.duration;
                enemyAi.damageBuff = knockbackBuff.attackDamage;

                enemyAi.anim = StrongCatAnimator;
                normalCat.SetActive(false);
                StrongCat.SetActive(true);
                break;

            case PlayerBuffHolder.BuffName.Giant:
                EnemyBuffReset();
                curretBuff = PlayerBuffHolder.BuffName.Giant;
                enemyAi.speedBuff = giantBuff.speed;
                enemyAi.attackSpeedBuff = giantBuff.attackSpeed;
                enemyAi.knockbackBuff = giantBuff.forceAttack;
                enemyAi.knockbackProtectionBuff = giantBuff.knockbackProtection;
                enemyAi.isAOE_Attack = true;
                duration = giantBuff.duration;
                enemyAi.damageBuff = giantBuff.attackDamage;

                enemyAi.anim = FatCatAnimator;
                normalCat.SetActive(false);
                FatCat.SetActive(true);

                break;
            case PlayerBuffHolder.BuffName.God:
                EnemyBuffReset();
                curretBuff = PlayerBuffHolder.BuffName.God;
                enemyAi.speedBuff = godBuff.speed;
                enemyAi.attackSpeedBuff = godBuff.attackSpeed;
                enemyAi.knockbackBuff = godBuff.forceAttack;
                enemyAi.knockbackProtectionBuff = godBuff.knockbackProtection;
                duration = godBuff.duration;
                enemyAi.damageBuff = godBuff.attackDamage;

                break;
        }
        checkReset = false;
    }

    public void EnemyBuffReset()
    {
        enemyAi.speedBuff = 1;
        enemyAi.knockbackBuff = 1;
        enemyAi.KnockbackRadiusBuff = 1;
        enemyAi.attackSpeedBuff = 1;
        enemyAi.knockbackProtectionBuff = 1;
        enemyAi.isAOE_Attack = false;
        enemyAi.anim = normalCatAnimator;
        enemyAi.damageBuff = 1;
        StrongCat.SetActive(false);
        SpeedCat.SetActive(false);
        FatCat.SetActive(false);
        normalCat.SetActive(true);
    }
}
