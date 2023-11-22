using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitPrefab : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if(GameData.health < 3)
            {
                player.GetComponent<Player>().health += 1; 
                Destroy(this.gameObject);
            }
        }
    }
}
