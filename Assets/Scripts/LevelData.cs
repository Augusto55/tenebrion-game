using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDate : MonoBehaviour
{
    private void OnDestroy()
    {
        GameData.lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
}
