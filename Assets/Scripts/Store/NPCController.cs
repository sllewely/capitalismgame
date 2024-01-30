using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float speed = 0.5f;
    public ItemDisplayController targetItem;
    public GameObject spawnPoint;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (spawnPoint.transform.position.y == rb.transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }
    
    void FixedUpdate()
    {
        if (targetItem != null)
        {
            move(targetItem.transform);
        } else
        {
            move(spawnPoint.transform);
        }
        
    }

    void move(Transform endLocation)
    {
        Vector3 direction = endLocation.transform.position - transform.position;
        direction.Normalize();
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (targetItem != null && collision.gameObject.name == targetItem.name)
        {
            targetItem.SellItem();
            targetItem = null;
        } else if (collision.gameObject.name == "Walls")
        {
            rb.isKinematic = true;
        }

    }
}
