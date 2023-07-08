using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TrapDamage : MonoBehaviour
{

    [SerializeField] protected int damage;
    protected bool isDamaging = false;
    [SerializeField] float durationKeepAlive = 15f;
    [SerializeField] float cooldownAttack;

    protected float cooldownTimer;
    

    protected void Start()
    {
        cooldownTimer = cooldownAttack;
        isDamaging = false;
    }
    protected void Update()
    {
        if (durationKeepAlive > 0 )
        {
            if (isDamaging && cooldownTimer >= cooldownAttack)
            {
                DamagePlayer();
                cooldownTimer = 0;

            }

            cooldownTimer += Time.deltaTime;
            durationKeepAlive -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDamaging = true;
            
        }
        

        //collision.GetComponent<HealthScript>().TakeDamage(damage);
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDamaging = false;
        }

    }

    protected void DamagePlayer()
    {
        Debug.Log("Plater IS Damaged");
        PlayerController.Instance.health.TakeDamage(damage);

    }

    

}
