using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MagAmmoManager : MonoBehaviour
{
    public int bullets;
    public int bulletsEmpty;
    public int invBullets;
    void Start()
    {
        
        bullets = GameData.bullets;
    }

    private void Update()
    {
        invBullets = GameData.invBullets;
        bullets = GameData.bullets;

        GetComponent<TextMeshProUGUI>().text = bullets.ToString();
    }

}
