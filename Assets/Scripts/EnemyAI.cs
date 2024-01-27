using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    RespawAI RespawAI;

    [Header("Other")]
    public NavMeshAgent agent;
    public List<GameObject> ListTarget;
    public GameObject player;
    public GameObject player2;
    public GameObject NearestOBJ;
    float distance;
    float nearestDistance = 10000;
    public Vector3 normalizedMovement;
    public float stopDistance;

    public Color EnemyrColor;
    public List<SpriteRenderer> enemyHands;

    [Header("EnemyStat")]
    public float MaxHP;
    public float EnemyHP;
    public float EnemyDamage;
    public float moveSpeed;
    public Animator anim;

    [Header("Attack")]
    public Transform pivotHitBox;
    public bool isAOE_Attack;
    public GameObject Hitbox;
    public bool CanAttack;
    public float attackDelay;
    float attackDelayTimer;
    public float baseKnockbackStrength;
    public float baseKnockbackRadius_AOE;
    public bool gethit;
    public GameObject attackEffectOBJ;

    [Header("TotalBuffValue")]
    public float totalKnockbackStrength;
    public float totalKnockbackRadius_AOE;
    public float totalEnemyDamage;

    [Header("BuffValue")]
    public float speedBuff = 1;
    public float knockbackBuff = 1;
    public float KnockbackRadiusBuff = 1;
    public float attackSpeedBuff = 1;
    public float knockbackProtectionBuff = 1;
    public float damageBuff = 1;

    public bool isDead;
    public bool Knockback;
    private void Awake()
    {
        EnemyHP = MaxHP;
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        ListTarget.Add(player);
        ListTarget.Add(player2);
        foreach (GameObject target in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (target != gameObject)
            {
                ListTarget.Add(target);
            }
        }

    }
        // Start is called before the first frame update
    void Start()
    {
        RespawAI = gameObject.GetComponent<RespawAI>();
        for (int i = 0; i < enemyHands.Count; i++)
        {
            enemyHands[i].color = EnemyrColor;
        }
        agent.updateRotation = false;
        attackDelayTimer = attackDelay;
    }

    // Update is called once per frame
    void Update()
    {
        totalKnockbackRadius_AOE = baseKnockbackRadius_AOE * KnockbackRadiusBuff;
        totalKnockbackStrength = baseKnockbackStrength * knockbackBuff;
        totalEnemyDamage = EnemyDamage + damageBuff;

        if (attackDelayTimer > 0)
        {
            attackDelayTimer -= Time.deltaTime * attackSpeedBuff;
        }
        else
        {
            CanAttack = true;
        }

        if (!isDead)
        {
            if (agent)
            {
                normalizedMovement = agent.desiredVelocity.normalized;
            }


            GameObject nearestObject = ListTarget[0];
            float distanceToNearest = Vector3.Distance(gameObject.transform.position, nearestObject.transform.position);

            for (int i = 0; i < ListTarget.Count; i++)
            {
                float distanceToCurrent = Vector3.Distance(gameObject.transform.position, ListTarget[i].transform.position);

                if (distanceToCurrent < distanceToNearest)
                {
                    nearestObject = ListTarget[i];
                    distanceToNearest = distanceToCurrent;

                }
            }
            NearestOBJ = nearestObject;

            float distanceTarget = Vector3.Distance(transform.position, NearestOBJ.transform.position);
            if (distanceTarget <= stopDistance)
            {
   
                agent.isStopped = true;
                
                EnemyAttack();
            }
            else
            {
                
                agent.isStopped = false;
                
            }

            if (!gethit)
            {
                agent.SetDestination(NearestOBJ.transform.position);

            }
        }
        anim.SetFloat("Horizontal", normalizedMovement.x);
        anim.SetFloat("Vertical", normalizedMovement.z);
        anim.SetFloat("Speed", normalizedMovement.sqrMagnitude);
        //pivotHitBox.transform.rotation = Quaternion.LookRotation(normalizedMovement);

        pivotHitBox.transform.LookAt(new Vector3(pivotHitBox.transform.position.x, NearestOBJ.transform.position.y, pivotHitBox.transform.position.z));
        pivotHitBox.transform.LookAt(NearestOBJ.transform);

        if (EnemyHP <= 0)
        {
            if (!isDead)
            {
                RespawAI.AIDead();
                isDead = true;
            }
        }
    }
    public void EnemyAttack()
    {
        if (CanAttack == true)
        {

            StartCoroutine(WaitCooldownAttack());

            //AudioManager_New.instance.PlaySFX("Hit");
            
        }
    }
    IEnumerator WaitCooldownAttack()
    {
        attackDelayTimer = attackDelay;
        CanAttack = false;
        GameObject effect = Instantiate(attackEffectOBJ, Hitbox.transform.position, Hitbox.transform.rotation
            );
        Destroy(effect, 0.5f);    
        Hitbox.SetActive(true);
        //HitboxEffect.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        Hitbox.SetActive(false);
        yield return new WaitForSeconds(0.15f);
        //HitboxEffect.SetActive(false);
    }

    public IEnumerator GetHit()
    {
        gethit = true;
        agent.enabled = false;
        yield return new WaitForSeconds(1);
        agent.enabled = true;
        gethit = false;
    }

    public void GetHit(float damage)
    {
        EnemyHP -= damage;
    }
}
