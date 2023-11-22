using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager12 : MonoBehaviour
{
    public Transform down;
    public Transform left;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    Vector3 position;

    private void Start()
    {
        if (GameData.lastSceneIndex == 10)
        {
            position = left.position;

        }
        else if (GameData.lastSceneIndex == 9)
        {
            position = down.position;
        }
        var spawnLocation = new Vector3(position.x, position.y, position.z);
        var player = Instantiate(playerPrefab, spawnLocation, Quaternion.identity);

        Instantiate(enemyPrefab, left.position, Quaternion.identity);
    }
}
