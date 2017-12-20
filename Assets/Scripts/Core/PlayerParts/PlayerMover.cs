using UnityEngine;

public class PlayerMover : MonoBehaviour {

    public FloatVariable Speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate() {
        var moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical") * Mathf.Sqrt(2));
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0;

        rb.MovePosition(rb.position + moveDirection * Speed.Value * Time.deltaTime);
    }
}
