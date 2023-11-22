using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager7 : MonoBehaviour
{
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform up;
    public GameObject playerPrefab;
    Vector3 position;

    private void Start()
    {
        if(GameData.lastSceneIndex == 8)
        {
            position = left.position;

        } else if (GameData.lastSceneIndex == 10)
        {
            position = up.position;
        } else if (GameData.lastSceneIndex == 9)
        {
            position = right.position;
        } else if (GameData.lastSceneIndex == 4)
        {
            position = down.position;
        }
            var spawnLocation = new Vector3(position.x, position.y, position.z);
        var player = Instantiate(playerPrefab, spawnLocation, Quaternion.identity);
    }
}

