using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager3 : MonoBehaviour
{
    public Transform down;
    public Transform up;
    public GameObject playerPrefab;
    Vector3 position;

    private void Start()
    {
        position = down.position;
        if (GameData.lastSceneIndex == 4)
        {
            position = up.position;
        }
        else if (GameData.lastSceneIndex == 2)
        {
            position = down.position;
        }
        var spawnLocation = new Vector3(position.x, position.y, position.z);
        var player = Instantiate(playerPrefab, spawnLocation, Quaternion.identity);
    }
}
