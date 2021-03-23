using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public static Player _playerInstance;
    Camera _camera;
    Rigidbody2D rb;

    float movement = 0f;

    public float movementSpeed = 10f;
    bool gameOver;

    public int score;

    void Awake() {
        if(_playerInstance == null) {
            _playerInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody2D>();   
        _camera = Camera.main;    
        // gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.instance.gameStarted) {
            movement = Input.GetAxis("Horizontal") * movementSpeed;

            Vector3 playerViewportPoint = _camera.WorldToViewportPoint(gameObject.transform.position);

            score = Mathf.Max(score, (int)transform.position.y);
            // Debug.LogWarning("Your score is: " + score);

            if(rb != null) {
                if(!GameController.instance.gameOver && playerViewportPoint.y < 0 || playerViewportPoint.x < 0 || playerViewportPoint.x > 1){
                    // Debug.Log(gameObject.ToString() + " is out of bounds");
                    // Destroy(gameObject);
                    // gameOver = true;
                    rb = null;
                    GameController.instance.gameOver = true;
                    GameController.instance.StopGame();
                }
            }
        }
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(movement, rb.velocity.y);
    }
}
