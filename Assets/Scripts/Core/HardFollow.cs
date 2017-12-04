using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardFollow : MonoBehaviour {
    private Vector3 offset;
    public GameObject Target;

	// Use this for initialization
	void Start () {
        offset = transform.position - Target.transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = Target.transform.position + offset;
	}
}
