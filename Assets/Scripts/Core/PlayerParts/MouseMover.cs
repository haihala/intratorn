using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMover : MonoBehaviour {

    public FloatVariable speed;
	public FloatVariable dead_zone;
	public IntVariable UIOpen;
    Rigidbody rb;
	Plane groundPlane;
	Vector3 target;

	void Start() {
        rb = GetComponent<Rigidbody>();
		groundPlane = new Plane(Vector3.up, new Vector3(0, 0, 0));
	}

    void Update() {
        if (UIOpen.Value == 0) {  // UIOpen is used to see if input for certain things should be captured.
			if (Input.GetMouseButtonDown(0)) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float distance;
				if (groundPlane.Raycast(ray, out distance)) {
					target = ray.GetPoint(distance);
				}
			}

			if (Input.GetButton("Stop")) {
				target = default(Vector3);
			}
		}
		if (target != default(Vector3)) {
			Vector3 move_direction = (target - transform.position);
			move_direction.y = 0;
			if (move_direction.magnitude > dead_zone.Value) {
				rb.MovePosition(rb.position + move_direction.normalized * speed.Value * Time.deltaTime);
			} else {
				target = default(Vector3);
			}
		}
    }
}
