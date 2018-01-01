using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPasser : MonoBehaviour {

	public float distance;
	void LateUpdate() {
		transform.position = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(distance);
	}
}
