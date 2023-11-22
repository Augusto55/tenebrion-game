using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTriggerEnemy : MonoBehaviour
{
    public GameObject enemyTrigger;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyTrigger.SetActive(true);
        }
        Destroy(gameObject, 4);
    }
}
