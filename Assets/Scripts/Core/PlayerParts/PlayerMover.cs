using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

    public FloatVariable Speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime;
        var y = Input.GetAxis("Vertical") * Time.deltaTime;

        Vector3 Dir = new Vector3(y+x, 0, y-x);
        rb.velocity = Dir.normalized * Speed.Value;
    }
}
