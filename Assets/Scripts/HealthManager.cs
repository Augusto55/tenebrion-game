using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject player;
    int health;
    Animator anim;

    private void Awake()
    {
        health = GameData.health;
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log(GameData.health);
        health = GameData.health;
        anim.SetInteger("Health", health);
    }

}
