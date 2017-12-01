using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour {
    private List<Interactable> Interactables = new List<Interactable>();
    private Vector3 Position;
    private Interactable Target;
    private Player Plr;

    private void Start() {
        Plr = GetComponent<Player>();
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
            if (NewTarget) {
                if (Target != NewTarget) {
                    if (Target) {
                        Target.DeHighlight();
                    }
                    Target = NewTarget;
                    Target.Highlight();
                }
            }
        }

        if (Input.GetButtonDown("Interact") && Target != null) {
            Target.Interact(Plr);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        Interactable interactable = RecursiveFinder.FromParent<Interactable>(collision.gameObject);

        if (interactable) {
            // We found something we can interact with
            Interactables.Add(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Interactable interactable = RecursiveFinder.FromParent<Interactable>(collision.gameObject);
        if (interactable) {
            // We found something we can interact with
            Interactables.Remove(interactable);
            if (interactable == Target) {
                Target.DeHighlight();
                Target = null;
            }
        }
    }
}
