using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager11 : MonoBehaviour
{
    public Transform down;
    public Transform right;
    public GameObject playerPrefab;
    Vector3 position;

    private void Start()
    {
        if (GameData.lastSceneIndex == 10)
        {
            position = right.position;
        }
        else if (GameData.lastSceneIndex == 8)
        {
            position = down.position;
        }
        var spawnLocation = new Vector3(position.x, position.y, position.z);
        var player = Instantiate(playerPrefab, spawnLocation, Quaternion.identity);
    }
}
