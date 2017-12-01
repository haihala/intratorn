using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    public FloatVariable Max_health;
    public FloatVariable Health;
    public StringVariable Name;
    public FloatVariable Speed;

    public Inventory inventory;

    protected Rigidbody2D rb;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
}
