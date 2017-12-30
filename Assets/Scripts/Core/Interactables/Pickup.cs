using UnityEngine;

public class Pickup : Interactable {
    public Item Content;

    public override void Interact(Player Plr) {
        Plr.Gather(Content);
        Destroy(gameObject);
    }
}