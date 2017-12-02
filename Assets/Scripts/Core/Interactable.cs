using UnityEngine;

public abstract class Interactable : MonoBehaviour {
    private GameObject HighlightPrefab;
    private GameObject HighlightObject;

    private void Start() {
        HighlightPrefab = PrefabManager.GetPrefab("Highlight");
    }

    public Vector3 Position () {
        return transform.position;
    }

    public virtual void Interact(Player Plr) { }

    public void Highlight() {
        if (HighlightObject == null) {
            HighlightObject = Instantiate(HighlightPrefab, transform);
        }
    }

    public void DeHighlight() {
        Destroy(HighlightObject);
    }
}
