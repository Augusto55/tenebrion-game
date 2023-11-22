using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static int invBullets {  get; set; }
    public static int health { get; set; }
    public static int bullets { get; set; }

    public static bool hasRun { get; set; } = false;
    public static bool hasRunHealth { get; set; } = false;

    public static int lastSceneIndex { get; set; }


    public static bool daruma { get; set; } = false;
    public static bool flower { get; set; } = false;
    public static bool coin { get; set; } = false;

    public static bool lockMovement { get; set; } = false;
}
