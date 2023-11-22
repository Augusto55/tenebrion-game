using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField] float xSpeed;
    [SerializeField] float ySpeed;

    public float playerX;
    public float playerY;

    public AnimatorStateInfo stateInfo;

    public MagAmmoManager magAmmoManager;


    public int health = 3;
    public float speed;

    Rigidbody2D rb;
    Animator anim;
    enum SideState { RIGHT, LEFT, UP , DOWN };
    public Vector2 shootingDirection;

    SideState state = SideState.RIGHT;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;



    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (!GameData.hasRun)
        {
            this.health = 3;
        }
        else
        {
            this.health = GameData.health;
        }
        
    }

    void Update()
    {
        Flip();
        SetAnim();
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        GameData.health = this.health;
        GameOver();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        playerX = Input.GetAxisRaw("Horizontal");
        playerY = Input.GetAxisRaw("Vertical");

        if(KBCounter <= 0 || !GameData.lockMovement)
        {
            Vector2 moveDir = new Vector2(playerX * xSpeed, playerY * ySpeed).normalized;
            rb.velocity = moveDir * speed;
        } else
        {
            if(KnockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, 0);
            } else
            {
                rb.velocity = new Vector2(KBForce, 0);
            }

            KBCounter -= Time.deltaTime;
        }
        
    }

    private void Flip()
    {
        if (playerX > 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
            state = SideState.RIGHT;
        }
        else if (playerX < 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
            state = SideState.LEFT;
        }
        if (playerY > 0)
        {
            state = SideState.UP;
        }
        else if (playerY < 0)
        {
            state = SideState.DOWN;
        }
    }

    void SetAnim()
    {
        anim.SetInteger("xSpeed", (int) playerX);
        anim.SetInteger("ySpeed", (int) playerY);
    }

    void GameOver()
    {
       
    }
}
