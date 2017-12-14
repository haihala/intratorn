using UnityEngine;

[CreateAssetMenu(menuName = "Galilei/IAction/Door")]
public class DoorAction : IAction {
    public override void OnInteract(GameObject target, Player Plr) {
        target.GetComponent<MeshCollider>().enabled = !target.GetComponent<MeshCollider>().enabled;
        target.GetComponent<MeshRenderer>().enabled = !target.GetComponent<MeshRenderer>().enabled;
    }
}