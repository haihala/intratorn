using UnityEngine;

public abstract class Interactable : MonoBehaviour {
    public Vector3 Position () {
        return transform.position;
    }

    public virtual void Interact(Player Plr) { }
}
