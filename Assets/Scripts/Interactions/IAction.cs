using UnityEngine;

public abstract class IAction : ScriptableObject {
    public abstract void OnInteract(GameObject target, Player Plr);
}