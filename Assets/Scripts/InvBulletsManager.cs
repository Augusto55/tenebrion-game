using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvBulletsManager : MonoBehaviour
{
    public int invBullets;
    void Start()
    {
        invBullets = GameData.invBullets;
    }

    
    void Update()
    {
        invBullets = GameData.invBullets;
        GetComponent<TextMeshProUGUI>().text = invBullets.ToString();
    }

    
}
