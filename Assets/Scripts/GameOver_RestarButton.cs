using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_RestarButton : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
