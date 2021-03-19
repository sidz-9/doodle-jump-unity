using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) {

        if(col.relativeVelocity.y <= 0f) {      // coming from top
            Rigidbody2D rb = col.collider.GetComponent<Rigidbody2D>();
            if(rb != null) {
                rb.velocity = new Vector2(0f, jumpSpeed);
            }
        }
    }
}
