using UnityEngine;

public abstract class InteractableAction : ScriptableObject {

    public abstract void OnInteract(GameObject target, Player Plr);
}