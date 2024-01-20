using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePlayerController : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody2D rb;
    Vector2 movement;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
