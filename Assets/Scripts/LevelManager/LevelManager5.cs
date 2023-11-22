using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager5 : MonoBehaviour
{
    public Transform right;
    public Transform up;
    public GameObject playerPrefab;
    Vector3 position;

    private void Start()
    {
        if (GameData.lastSceneIndex == 8)
        {
            position = up.position;
        }
        else if (GameData.lastSceneIndex == 4)
        {
            position = right.position;
        }
        var spawnLocation = new Vector3(position.x, position.y, position.z);
        var player = Instantiate(playerPrefab, spawnLocation, Quaternion.identity);
    }
}
