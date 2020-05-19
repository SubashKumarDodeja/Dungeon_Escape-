using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy,IDamagable
{
    public GameObject acidEffectPrefab;
    public int Health { set; get; }

    public override void Update()
    {

    }

    public void Damage()
    {
        if (isDead)
            return;
        Debug.Log("SpiderDamage");
        Health--;
        if (Health < 1)
        {

            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Daimond>().gems = base.gems;
        }
    }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Movement()
    {
    }

    public void Attack()
    {

        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
