using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour,IDamagable
{
    public int Daimonds=0;

    PlayerAnimation _playeranim;
    Rigidbody2D _playerrigid;
    SpriteRenderer _playersprite;
    SpriteRenderer _swordArcsprite; 
    
    [SerializeField]
    float _jumpForce= 5f;

    [SerializeField]
    float _speed = 5f;

    bool _resetJumpNeeded = false;
    
    bool _grounded=false;

    public int Health { get ; set; }

    // Start is called before the first frame update
    void Start()
    {
        _playerrigid = GetComponent<Rigidbody2D>();
        _playeranim = GetComponent<PlayerAnimation>();
        _playersprite = GetComponentInChildren<SpriteRenderer>();
        _swordArcsprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();        
        if( CrossPlatformInputManager.GetButtonDown("A_Button")  && _grounded== true)
        {
            _playeranim.Attack();
         }

    }
    IEnumerator ResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(1);
        _resetJumpNeeded = false;
    }


    void Movement()
    {
        float move = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        flip(move);

        if ( CrossPlatformInputManager.GetButtonDown("B_Button") && _grounded == true)
        {
            _playerrigid.velocity = new Vector2(_playerrigid.velocity.x, _jumpForce);
            _grounded = false;
            _resetJumpNeeded = true;
            StartCoroutine(ResetJumpNeededRoutine());
            _playeranim.Jump(true);

        }
        _playerrigid.velocity = new Vector2(move * _speed, _playerrigid.velocity.y);

        _playeranim.Move(move*_speed);

        CheckGrounded();
    }

    void CheckGrounded()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green);

        if (hit.collider != null)
        {
            if (_resetJumpNeeded == false)
            {
                _grounded = true;
                _playeranim.Jump(false);
            }
                
        }
    }

    void flip(float move)
    {
        if (move > 0)
        {
            _playersprite.flipX = false;
            _swordArcsprite.flipX = false;
            _swordArcsprite.flipY = false;
            Vector3 pos = _swordArcsprite.transform.localPosition;
            pos.x = 1.01f;
            _swordArcsprite.transform.localPosition = pos;
        }
        else if (move < 0)
        {
            _playersprite.flipX = true;
            _swordArcsprite.flipX = true;
            _swordArcsprite.flipY = true;
            Vector3 pos = _swordArcsprite.transform.localPosition;
            pos.x = -1.01f;
            _swordArcsprite.transform.localPosition = pos;

        }

    }

    public void Damage()
    {

        if (Health < 1)
            return;
        Debug.Log("PlayerDamage");
        Health--;
        UIManager.Instance.UpdateLifes(Health);
        if(Health<1)
        {
            _playeranim.Death();
        }
      
    }

    public void AddGems(int amount)
    {
        Daimonds += amount;
        UIManager.Instance.UpdateGemCount(Daimonds);
    }
}
