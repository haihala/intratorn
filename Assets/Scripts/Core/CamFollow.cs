using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {
    public Transform target;
    public float distance;

    float heightOffset;
    float widthOffset;

    void Start() {
        heightOffset = distance/(float)Math.Sqrt(2);
        widthOffset = distance/2;
    }

	void Update () {
        transform.position = new Vector3(
            target.position.x - widthOffset, 
            target.position.y + heightOffset, 
            target.position.z - widthOffset
            );
    }
}