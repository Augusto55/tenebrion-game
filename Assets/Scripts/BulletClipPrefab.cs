using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletClipPrefab : MonoBehaviour
{
    GameObject gun;

    private void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int bulletDrop = Random.Range(2, 9);
        if (collision.gameObject.CompareTag("Player"))
        {
            gun.GetComponent<Gun>().invBullets += bulletDrop;
            Destroy(this.gameObject);
        }
    }
}
