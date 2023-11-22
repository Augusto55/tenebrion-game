using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadText : MonoBehaviour
{
    public GameObject player;
    public GameObject gun;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.SetActive(false);
    }


    void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position;
    }
}
