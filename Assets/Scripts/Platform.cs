using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpSpeed = 10f;

    Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        DespawnPlatform();
    }

    void OnCollisionEnter2D(Collision2D col) {

        if(col.relativeVelocity.y <= 0f) {      // coming from top
            Rigidbody2D rb = col.collider.GetComponent<Rigidbody2D>();
            if(rb != null) {
                rb.velocity = new Vector2(0f, jumpSpeed);
            }
        }
    }

    // Viewport space is normalized and relative to the camera. The bottom-left of the camera is (0,0); the top-right is (1,1)
    // so here we are checking if the viewport point of platform is less than zero(means the platform is below the camera)
    void DespawnPlatform() {
        if(_camera.WorldToViewportPoint(gameObject.transform.position).y < 0){
            Debug.Log(gameObject.ToString() + "Destroyed");
            Destroy(gameObject);
        }
    }
}
