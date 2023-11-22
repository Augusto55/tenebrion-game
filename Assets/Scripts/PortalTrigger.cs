using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PortalTrigger : MonoBehaviour
{
    public TextMeshProUGUI itemWarning;
    public GameObject enemySeal;

    private void Start()
    {
        itemWarning.gameObject.SetActive(false);
        enemySeal.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(GameData.daruma && GameData.coin && GameData.flower)
            {
                GameData.lockMovement = true;
                enemySeal.SetActive(true);
            } else
            {
                itemWarning.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(itemWarning.gameObject.activeSelf == true)
        {
            itemWarning.gameObject.SetActive(false);
        }
    }
}
