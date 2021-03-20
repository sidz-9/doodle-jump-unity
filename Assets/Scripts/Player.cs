using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Camera _camera;
    Rigidbody2D rb;

    float movement = 0f;

    public float movementSpeed = 10f;
    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        _camera = Camera.main; 
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 playerViewportPoint = _camera.WorldToViewportPoint(gameObject.transform.position);

        if(gameObject != null) {
            if(!gameOver && playerViewportPoint.y < 0 || playerViewportPoint.x < 0 || playerViewportPoint.x > 1){
                // Debug.Log(gameObject.ToString() + " is out of bounds");
                Destroy(gameObject);
                gameOver = true;
            }
        }
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(movement, rb.velocity.y);
    }
}
