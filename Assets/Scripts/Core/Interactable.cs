using UnityEngine;

public class Interactable : MonoBehaviour {
    public InteractableAction Action;
    public GameObject HighlightPrefab;
    private GameObject HighlightObject;

    public Vector3 Position () {
        return transform.position;
    }

    public void Interact (Player player) {
        Action.OnInteract(gameObject, player);
    }

    public void Highlight() {
        if (HighlightObject == null) {
            HighlightObject = Instantiate(HighlightPrefab, transform);
        }
    }

    public void DeHighlight() {
        Destroy(HighlightObject);
    }
}
