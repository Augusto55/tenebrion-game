using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerTrigger : MonoBehaviour
{
    private void Start()
    {
        if (GameData.flower == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameData.flower = true;
        }
    }
}
