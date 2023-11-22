using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager6 : MonoBehaviour
{
    public Transform left;
    public Transform up;
    public GameObject playerPrefab;
    Vector3 position;

    private void Start()
    {
        if (GameData.lastSceneIndex == 4)
        {
            position = left.position;

        }
        else if (GameData.lastSceneIndex == 9)
        {
            position = up.position;
        }
        var spawnLocation = new Vector3(position.x, position.y, position.z);
        var player = Instantiate(playerPrefab, spawnLocation, Quaternion.identity);
    }
}
