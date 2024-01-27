using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBuffHolder : MonoBehaviour
{
    public PlayerController playerController;
    [Header("Buffs")]
    public float duration;
    public BuffName curretBuff;

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
    public enum BuffName
    {
        None,
        Speed,
        Giant,
        God,
        Knockback
    }
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (curretBuff != BuffName.None)
        {
            duration -= Time.deltaTime;
        }

        if (duration <= 0)
        {
            curretBuff = BuffName.None;
            duration = 0;
            if (!checkReset)
            {
                PlayerBuffReset();
                checkReset = true;
            }
        }
    }

    public void PlayerGetBuff(BuffName _buff)
    {
        
        switch (_buff)
        {

            case BuffName.None:

                break;

            case BuffName.Speed:
                PlayerBuffReset();
                curretBuff = BuffName.Speed;
                playerController.speedBuff = speedBuff.speed;
                playerController.attackSpeedBuff = speedBuff.attackSpeed;
                duration = speedBuff.duration;
                playerController.damageBuff = speedBuff.attackDamage;

                playerController.anim = SpeedCatAnimator;
                normalCat.SetActive(false);
                SpeedCat.SetActive(true);

                break;
            case BuffName.Knockback:
                PlayerBuffReset();
                curretBuff = BuffName.Knockback;
                playerController.knockbackBuff = knockbackBuff.forceAttack;
                playerController.knockbackProtectionBuff = knockbackBuff.knockbackProtection;
                duration = knockbackBuff.duration;
                playerController.damageBuff = knockbackBuff.attackDamage;

                playerController.anim = StrongCatAnimator;
                normalCat.SetActive(false);
                StrongCat.SetActive(true);
                break;

            case BuffName.Giant:
                PlayerBuffReset();
                curretBuff = BuffName.Giant;
                playerController.speedBuff = giantBuff.speed;
                playerController.attackSpeedBuff = giantBuff.attackSpeed;
                playerController.knockbackBuff = giantBuff.forceAttack;
                playerController.knockbackProtectionBuff = giantBuff.knockbackProtection;
                playerController.isAOE_Attack = true;
                duration = giantBuff.duration;
                playerController.damageBuff = giantBuff.attackDamage;

                playerController.anim = FatCatAnimator;
                normalCat.SetActive(false);
                FatCat.SetActive(true);

                break;
            case BuffName.God:
                PlayerBuffReset();
                curretBuff = BuffName.God;
                playerController.speedBuff = godBuff.speed;
                playerController.attackSpeedBuff = godBuff.attackSpeed;
                playerController.knockbackBuff = godBuff.forceAttack;
                playerController.knockbackProtectionBuff = godBuff.knockbackProtection;
                duration = godBuff.duration;
                playerController.damageBuff = godBuff.attackDamage;

                break;
        }
        checkReset = false;
    }

    public void PlayerBuffReset()
    {
        playerController.speedBuff = 1;
        playerController.knockbackBuff = 1;
        playerController.KnockbackRadiusBuff = 1;
        playerController.attackSpeedBuff = 1;
        playerController.knockbackProtectionBuff = 1;
        playerController.isAOE_Attack = false;
        playerController.anim = normalCatAnimator;
        StrongCat.SetActive(false);
        SpeedCat.SetActive(false);
        FatCat.SetActive(false);
        normalCat.SetActive(true);
    }
}
