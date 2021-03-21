using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool gameOver;

    public bool gameStarted = false;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver && Input.GetMouseButtonDown(0)) {
            gameStarted = true;
            StartGame();
        }
    }

    public void StartGame() {
        UiController.instance.GameStart();
        PlatformSpawner._platformSpawnerInstance.StartSpawningPlatforms();
    }

    public void StopGame() {
        UiController.instance.GameOver();
        gameOver = true;
        // ScoreController.instance.StopScore();
    }
}
