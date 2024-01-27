using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isPlayer2;
    public Color PlayerColor;
    public List<SpriteRenderer> playerHands;
    public Camera playerCamera;
    public RespawPlayer playerRespaw;

    [Header("PlayerStat")]
    public float MaxHP;
    public float playerHP;
    public float playerDamage;
    public float moveSpeed;
    Rigidbody rb;
    public Vector3 InputKey;
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
    public GameObject attackEffectOBJ;


    [Header("TotalBuffValue")]
    public float totalKnockbackStrength;
    public float totalKnockbackRadius_AOE;
    public float totalPlayerDamage;

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
        playerHP = MaxHP;

        for (int i = 0;i < playerHands.Count; i++)
        {
            playerHands[i].color = PlayerColor;
        }
       
        attackDelayTimer = attackDelay;
        //anim = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            //pivotHitBox.transform.LookAt(new Vector3(hit.point.x, pivotHitBox.transform.position.y, hit.point.z));
            //pivotHitBox.transform.LookAt(hit.point);

            // Do something with the object that was hit by the raycast.
        }

        totalKnockbackRadius_AOE = baseKnockbackRadius_AOE * KnockbackRadiusBuff;
        totalKnockbackStrength = baseKnockbackStrength * knockbackBuff;
        totalPlayerDamage = playerDamage + damageBuff;

        if (attackDelayTimer > 0)
        {
            attackDelayTimer -= Time.deltaTime * attackSpeedBuff;
        }
        else
        {
            CanAttack = true;
        }

        if (!isPlayer2)
        {
            if (!isDead)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ClickMouseAttack();
                }
                InputKey = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            }

            anim.SetFloat("Horizontal", InputKey.x);
            anim.SetFloat("Vertical", InputKey.z);
            anim.SetFloat("Speed", InputKey.sqrMagnitude);

            pivotHitBox.transform.eulerAngles = InputKey;
            pivotHitBox.transform.rotation = Quaternion.LookRotation(InputKey);
        }
        else
        {
            if (!isDead)
            {
                if (Input.GetKeyDown(KeyCode.Keypad0))
                {
                    ClickMouseAttack();
                }
                InputKey = new Vector3(Input.GetAxis("Horizontal2"), 0, Input.GetAxis("Vertical2")).normalized;
            }
            anim.SetFloat("Horizontal", InputKey.x);
            anim.SetFloat("Vertical", InputKey.z);
            anim.SetFloat("Speed", InputKey.sqrMagnitude);

            pivotHitBox.transform.eulerAngles = InputKey;
            pivotHitBox.transform.rotation = Quaternion.LookRotation(InputKey);
        }
        
        if(playerHP <= 0)
        {
            if (!isDead)
            {
                playerRespaw.PlayerDead(gameObject);
                isDead = true;
            }
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
            
                StartCoroutine(WaitCooldownAttack());
                //AudioManager_New.instance.PlaySFX("Hit");
            
        }
    }
    IEnumerator WaitCooldownAttack()
    {
        attackDelayTimer = attackDelay;
        CanAttack = false;
        Instantiate(attackEffectOBJ, Hitbox.transform.position, Hitbox.transform.rotation);
        Hitbox.SetActive(true);
        //HitboxEffect.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        Hitbox.SetActive(false);
        yield return new WaitForSeconds(0.13f);
        //HitboxEffect.SetActive(false);
    }

    public void GetHit(float damage)
    {
        playerHP -= damage;
        Debug.Log(gameObject.name + " : " + playerHP);
    }
}
