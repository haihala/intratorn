using UnityEngine;

public class InteractableAction : Interactable {
    public IAction Action;

    public override void Interact (Player Plr) {
        Action.OnInteract(gameObject, Plr);
    }
}
