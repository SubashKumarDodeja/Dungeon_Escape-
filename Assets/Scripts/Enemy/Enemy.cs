using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public GameObject diamondPrefab;

    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;


    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected bool isHit=false;

    protected bool isDead = false;



    protected Player player;
    void Start()
    {
        Init();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void Init()
    {

        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    } 

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat")==false )
        {
            return;
        }

        if(isDead==false)
            Movement();
    }

    public virtual void Movement()
    {
        

        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }
        else
        {

            sprite.flipX = false;
        }


        if (transform.position == pointA.position)
        {
            //Debug.Log("pointA");
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");

        }
        else if (transform.position == pointB.position)
        {

            //Debug.Log("pointB");
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");

        }
        if(isHit==false)
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if (distance > 2)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }

        //direction
        Vector3 direction = player.transform.localPosition - transform.localPosition;

        // Debug.Log("Direction:" + direction.x);
        if (direction.x > 0 && anim.GetBool("InCombat") == true)
            sprite.flipX = false;
        else if (direction.x < 0 && anim.GetBool("InCombat") == true)
            sprite.flipX = true;


    }



}
