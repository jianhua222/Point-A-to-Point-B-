using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PlayerInfoHolder : object {
    public static int level { get; set;}
    public static int health{ get; set;}
    public static int exp { get; set; }
    public static int farStage { get; set; }
}
