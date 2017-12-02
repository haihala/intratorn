using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PrefabManager {
    public static GameObject GetPrefab(string Name) {
        return (GameObject)Resources.Load("prefabs/" + Name, typeof(GameObject));
    }
}
