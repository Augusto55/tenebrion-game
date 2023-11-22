using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySealScript : MonoBehaviour
{
    Animator anim;
    public GameObject fade;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("isSealed", GameData.lockMovement);
        if (GameData.lockMovement)
        {
            StartCoroutine(DestroyEnemy());
        }
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        fade.SetActive(true);
        StartCoroutine(Exit());
    }

    IEnumerator Exit()
    {
        yield return new WaitForSeconds(3f);
        Application.Quit();
    }
}
