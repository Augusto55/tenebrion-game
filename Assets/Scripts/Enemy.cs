using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    bool isDead = false;
    Animator anim;
    float health = 2;
    public GameObject player;
    AudioSource audioSource;
    GameObject backgroundMusic;
    public GameObject medkitPrefab;
    public GameObject bulletclipPrefab;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();


        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");

        anim.SetBool("isDead", isDead);

        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
        Flip();

        Debug.Log(player.GetComponent<Player>().health);

    }

    private void FixedUpdate()
    {
        if (target && !isDead)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;

        }
        else
        {
            rb.velocity = Vector2.zero;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("BehindPlayer");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shot"))
        {
            health -= 1;
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                isDead = true;
                audioSource.Stop();
                Destroy(this.gameObject, 5);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameData.health == 1)
            {
                backgroundMusic = GameObject.FindGameObjectWithTag("BGMusic");
                Destroy(backgroundMusic);
                SceneManager.LoadScene(13);
            }
            player.GetComponent<Player>().KBCounter = player.GetComponent<Player>().KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                player.GetComponent<Player>().KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                player.GetComponent<Player>().KnockFromRight = false;
            }
            player.GetComponent<Player>().health -= 1;
            
        }
    }



    private void Flip()
    {
        if (moveDirection.x < 0 && !isDead)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (moveDirection.x > 0 && !isDead)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    private void OnDestroy()
    {
        if(isDead) { 
            RollDropChance(); 
        }  
    }

    void RollDropChance()
    {
        float m_dropChance = 1f / 10f;
        if (Random.Range(0f, 1f) <= m_dropChance)
        {
            int resultado = Random.Range(1, 3);
            switch (resultado)
            {
                case 1:
                    Instantiate(medkitPrefab, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(bulletclipPrefab, transform.position, Quaternion.identity);
                    break;
            }
        }
    }

}
