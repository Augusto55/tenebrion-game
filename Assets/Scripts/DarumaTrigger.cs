using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarumaTrigger : MonoBehaviour
{
    private void Start()
    {
        if (GameData.daruma == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameData.daruma = true;
        }
    }
}
