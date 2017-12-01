using UnityEngine;

[CreateAssetMenu(menuName = "Galilei/IAction/Pickup")]
public class PickupAction : InteractableAction {
    public Item Pickup;

    public override void OnInteract(GameObject target, Player Plr) {
        Plr.Gather(Pickup);
    }
}