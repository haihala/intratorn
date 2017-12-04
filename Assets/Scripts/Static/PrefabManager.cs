using UnityEngine;

public static class PrefabManager {
    public static GameObject GetPrefab(string Name) {
        return (GameObject)Resources.Load("Prefabs/" + Name, typeof(GameObject));
    }
}
