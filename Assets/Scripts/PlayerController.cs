using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Color PlayerColor;
    public SpriteRenderer playerHands;
    [Header("PlayerStat")]
    public float playerHP;
    public float playerDamage;
    public float moveSpeed;
    Rigidbody rb;
    Vector3 InputKey;
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
   
    [Header("TotalBuffValue")]
    public float totalKnockbackStrength;
    public float totalKnockbackRadius_AOE;

    [Header("BuffValue")]
    public float speedBuff = 1;
    public float knockbackBuff = 1;
    public float KnockbackRadiusBuff = 1;
    public float attackSpeedBuff = 1;
    public float knockbackProtectionBuff = 1;
    public float damageBuff = 1;

    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        playerHands.color = PlayerColor;
        attackDelayTimer = attackDelay;
        //anim = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        totalKnockbackRadius_AOE = baseKnockbackRadius_AOE * KnockbackRadiusBuff;
        totalKnockbackStrength = baseKnockbackStrength * knockbackBuff;

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
            ClickMouseAttack();
            InputKey = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        }

        anim.SetFloat("Horizontal", InputKey.x);
        anim.SetFloat("Vertical", InputKey.z);
        anim.SetFloat("Speed", InputKey.sqrMagnitude);

        if(InputKey.x >= 0.1f)
        {
            pivotHitBox.transform.eulerAngles = new Vector3(0, -90, 0);
            //rb.AddForce(transform.forward * moveSpeed * speedBuff);
        }
        else if(InputKey.x <= -0.1f)
        {
            pivotHitBox.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else if(InputKey.z >= 0.1f)
        {
            pivotHitBox.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (InputKey.z <= -0.1f)
        {
            pivotHitBox.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            pivotHitBox.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            InputKey = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector3) transform.position + ((InputKey * moveSpeed)* speedBuff) * Time.deltaTime);
        //rb.AddForce(InputKey * moveSpeed * speedBuff);
        rb.mass = knockbackProtectionBuff;
    }

    public void ClickMouseAttack()
    {
        if (CanAttack == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(WaitCooldownAttack());
            }
        }
    }
    IEnumerator WaitCooldownAttack()
    {
        attackDelayTimer = attackDelay;
        CanAttack = false;
        Hitbox.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        Hitbox.SetActive(false); 
    }
}
