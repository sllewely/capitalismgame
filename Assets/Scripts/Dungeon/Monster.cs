using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monster : MonoBehaviour
{
    public float health;
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
            Destroy(gameObject);
            Debug.Log("shep is ded!");
        }
        immuneForSeconds -= Time.deltaTime;
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
