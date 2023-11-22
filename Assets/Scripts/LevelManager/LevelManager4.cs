using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager4 : MonoBehaviour
{
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform up;
    public GameObject playerPrefab;
    Vector3 position;

    private void Start()
    {
        position = down.position;
        if (GameData.lastSceneIndex == 5)
        {
            position = left.position;

        }
        else if (GameData.lastSceneIndex == 7)
        {
            position = up.position;
        }
        else if (GameData.lastSceneIndex == 6)
        {
            position = right.position;
        }
        else if (GameData.lastSceneIndex == 3)
        {
            position = down.position;
        }
        var spawnLocation = new Vector3(position.x, position.y, position.z);
        var player = Instantiate(playerPrefab, spawnLocation, Quaternion.identity);
    }
}
