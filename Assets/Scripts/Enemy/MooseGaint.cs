using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooseGaint : Enemy, IDamagable
{

    public int Health { set; get; }

    public void Damage()
    {
        if (isDead)
            return;
        Debug.Log("MooseGaintDamage()");
        Health--;
        anim.SetTrigger("Hit");

        isHit = true;
        anim.SetBool("InCombat", true);
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond= Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Daimond>().gems=base.gems; 
       
        }
    }

    public override void Init()
    {
        Health = base.health;
        base.Init();
    }
    public override void Movement()
    {
        base.Movement();
        
    }
}
