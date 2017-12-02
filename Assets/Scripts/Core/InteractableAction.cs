using UnityEngine;

public class InteractableAction : Interactable {
    public IAction Action;

    public virtual void Interact (Player Plr) {
        Action.OnInteract(gameObject, Plr);
    }
}
