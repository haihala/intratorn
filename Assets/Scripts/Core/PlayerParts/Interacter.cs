using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour {
    private List<Interactable> Interactables = new List<Interactable>();
    private Vector3 Position;
    private Interactable Target;
    private Player Plr;
    private GameObject HighlightPrefab;
    private GameObject HighlightObject;

    private void Start() {
        Plr = GetComponent<Player>();
        HighlightPrefab = PrefabManager.GetPrefab("UI/Highlight");
    }

    // Update is called once per frame
    void Update() {
        if (transform.position != Position) {
            // Check only after moving
            Position = transform.position;
            float Range = -1;
            Interactable NewTarget = null;

            foreach (Interactable i in Interactables) {
                float TempRange = (i.Position() - Position).magnitude;
                if (TempRange < Range || Range == -1) {
                    Range = TempRange;
                    NewTarget = i;
                }
            }

            Target = NewTarget;
            
            if (Target)
            {
                Retarget();
            }
        }

        if (Input.GetButtonDown("Interact") && Target != null) {
            Target.Interact(Plr);
        }
	}

    private void Retarget()
    {
        if (!HighlightObject)
        {
            HighlightObject = Instantiate(HighlightPrefab);
        }

        var combinedBounds = new Bounds();
        var renderers = Target.GetComponentsInChildren<Renderer>();
        foreach (Renderer render in renderers)
        {
            combinedBounds.Encapsulate(render.bounds);
        }
        HighlightObject.transform.position = new Vector3( Target.gameObject.transform.position.x, combinedBounds.max.y + 0.1f, Target.gameObject.transform.position.z);

    }

    private void Untarget()
    {
        if (HighlightObject)
        {
            Destroy(HighlightObject);
        }
    }

    private void OnTriggerEnter(Collider collision) {
        Interactable interactable = RecursiveFinder.FromParent<Interactable>(collision.gameObject);
        if (interactable) {
            // We found something we can interact with
            Interactables.Add(interactable);
        }
    }

    private void OnTriggerExit(Collider collision) {
        Interactable interactable = RecursiveFinder.FromParent<Interactable>(collision.gameObject);
        if (interactable) {
            // We found something we can interact with
            Interactables.Remove(interactable);
            if (interactable == Target) {
                Untarget();
                Target = null;
            }
        }
    }
}
