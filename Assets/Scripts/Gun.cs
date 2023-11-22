using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Gun : MonoBehaviour
{

    [SerializeField] GameObject player;
    public GameObject capsule;
    public Sprite gunSideways;
    public Sprite gunDown;
    public Sprite gunUp;
    public Transform sidePosition;
    public Transform upPosition;
    public Transform downPosition;

    float timer;
    [SerializeField] float shotTimer;
    [SerializeField] GameObject bullet;
    Vector2 shootingDirection;
    float shootRotation;

    int bullets;
    int bulletsEmpty;
    public int invBullets;
    //public GameObject[] ammo;
    public MagAmmoManager magAmmoManager;
    public bool isReloading = false;
    public GameObject reloadText;
    private bool isShooting;

    public AudioSource gunshot;   
    public AudioSource gunReloading;

    void Start()
    {
        if (!GameData.hasRun)
        {
            bullets = 7;
            invBullets = 10;
            GameData.hasRun = true;
        }
        else
        {
            this.bullets = GameData.bullets;
            this.invBullets = GameData.invBullets;
        }
        reloadText = GameObject.FindGameObjectWithTag("ReloadText").transform.GetChild(0).gameObject;
    }

    void Update()
    {
        Flip();
        FlipSprite();
        Shot();
        Reload();
        if (isShooting)
        {
            ResetShootingFlag();
        }
        GameData.invBullets = this.invBullets;
        GameData.bullets = this.bullets;
    }

    void Flip()
    {
        if (player.GetComponent<Player>().playerX > 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (player.GetComponent<Player>().playerX < 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        } 


    }

    void FlipSprite()
    {
        if (player.GetComponent<Player>().stateInfo.IsName("idle_side") || player.GetComponent<Player>().stateInfo.IsName("side_walking"))
        {
            this.GetComponent<SpriteRenderer>().sprite = gunSideways;
            transform.position = sidePosition.position;
            if (player.GetComponent<Player>().playerX > 0)
            {
                shootingDirection = Vector2.right;
            }
            else if (player.GetComponent<Player>().playerX < 0)
            {
                shootingDirection = Vector2.left;
            }
            shootRotation = 90;
        } else if (player.GetComponent<Player>().stateInfo.IsName("idle_vertical") || player.GetComponent<Player>().stateInfo.IsName("up_down_walking"))
        {
            if (player.GetComponent<Player>().playerY > 0)
            {
                this.GetComponent<SpriteRenderer>().sprite = gunUp;
                transform.position = upPosition.position;
                shootingDirection = Vector2.up;
            }
            else if (player.GetComponent<Player>().playerY < 0)
            {
                this.GetComponent<SpriteRenderer>().sprite = gunDown;
                transform.position = downPosition.position;
                shootingDirection = Vector2.down;
            }
            shootRotation = 0;
        }
    }

    void Shot()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > timer && bullets != 0 && !isReloading)
        {
            timer = Time.time + shotTimer;
            isShooting = true;
            ResetShootingFlag();
            GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, shootRotation));
            bulletClone.GetComponent<Rigidbody2D>().velocity = shootingDirection * 45;
            gunshot.Play();
            Destroy(bulletClone, 2);
            StartCoroutine(EjectCapsule());
            bullets -= 1;
            //ammo[bullets].gameObject.SetActive(false);
            //var teste = GetComponent<MagAmmoManager>().ammo;
            //teste[bullets].SetActive(false);
        }
    }
    IEnumerator ResetVelocity(GameObject clone)
    {
        yield return new WaitForSeconds(0.4f);
        
        clone.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
    }

    IEnumerator EjectCapsule()
    {
        yield return new WaitForSeconds(1f);
        gunReloading.Play();
        GameObject capsuleClone = Instantiate(capsule, transform.position, Quaternion.Euler(0, 0, 0));
        capsuleClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootingDirection.x * 2, 0);
        StartCoroutine(ResetVelocity(capsuleClone));
        Destroy(capsuleClone, 4);
    }

    void Reload()
    {   
        if ((bullets == 0 || Input.GetKeyDown(KeyCode.R)) && invBullets != 0 && GameData.bullets != 7)
        {

            reloadText.SetActive(true);
            if (!isReloading)
            {
                StartCoroutine(ReloadDelay());
            }
        }
    }

    IEnumerator ReloadDelay()
    {
        isReloading = true;


        yield return new WaitForSeconds(2);
        gunReloading.Play();



        CalculateBulletsLeft();

        //for (int i =0; i < bullets; i++)
        //{
        //    ammo[i].gameObject.SetActive(true);
        //}
        //for (int i = 0; i < bullets; i++)
        //{
        //    var teste = GetComponent<MagAmmoManager>().ammo;
        //    teste[i].SetActive(true);

        //}


        reloadText.SetActive(false);

        isReloading = false;
    }

    IEnumerator ResetShootingFlag()
    {
        yield return new WaitForSeconds(2.0f);
        isShooting = false;

    }

   

    void CalculateBulletsLeft()
    {
        bulletsEmpty = 7 - bullets;
        invBullets = invBullets - bulletsEmpty;
        if (invBullets < 0)
        {
            bullets += invBullets * (-1);
            invBullets = 0;
        }
        else
        {
            bullets = 7;
        }

    }

}

