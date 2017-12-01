using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

    public FloatVariable Speed;

    private Rigidbody2D rb;
    private float StopDrag;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        StopDrag = rb.drag;
	}
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime;
        var y = Input.GetAxis("Vertical") * Time.deltaTime;

        // Suboptimal, fix later
        if (x==0 && y==0) {
            rb.drag = StopDrag;
        } else {
            rb.drag = 5;
        }

        Vector3 Dir = new Vector3(x, y);
        //print(Dir);
        rb.AddForce(Dir * Speed.Value);
    }
}
