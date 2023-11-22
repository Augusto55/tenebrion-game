using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.EventSystems;

public class EnemyTrigger : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform target;
    Vector2 moveDirection;
    void Start()
    {
        gameObject.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
        
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * 5;

    }

}