using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMineTrap : TrapDamage
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();    
        base.Start();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        animator.SetTrigger("PlayerON");
        
    }
}
