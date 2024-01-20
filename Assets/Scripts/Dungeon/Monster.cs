using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monster : MonoBehaviour
{
    public float health;
    public GameObject dropItem;
    public float immuneSecondsOnHit = 0.3f;
    private float immuneForSeconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {

            Debug.Log("shep is ded!");
            Instantiate(dropItem, transform.position + Vector3.up*1.0f, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            immuneForSeconds -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("shep collision");

        // TODO: switch out of using tags and instead get GameObject and check state
        if (collider.gameObject.tag == "weapon")
        {
            if (immuneForSeconds > 0.0) { return; }
            immuneForSeconds = immuneSecondsOnHit;
            health -= 1;
            Debug.Log("hit! health: " + health);
        }
    }
}
