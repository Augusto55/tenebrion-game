using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager9 : MonoBehaviour
{
    public Transform down;
    public Transform left;
    public Transform up;
    public GameObject playerPrefab;
    Vector3 position;

    private void Start()
    {
        if (GameData.lastSceneIndex == 7)
        {
            position = left.position;

        }
        else if (GameData.lastSceneIndex == 12)
        {
            position = up.position;
        }
        else if (GameData.lastSceneIndex == 6)
        {
            position = down.position;
        }
        var spawnLocation = new Vector3(position.x, position.y, position.z);
        var player = Instantiate(playerPrefab, spawnLocation, Quaternion.identity);
    }
}
