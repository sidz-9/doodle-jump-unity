using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public static UiController instance;
    public GameObject endGamePanel;
    public GameObject tapToStartText;
    public GameObject gameOverImage;
    public Text scoreText;
    public Text highScoreText;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // scoreText.text = ScoreController.instance.score.ToString();
    }

    public void GameStart() {
        tapToStartText.SetActive(false);
    }
    public void GameOver() {
        endGamePanel.SetActive(true);
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }

    public void Replay() {
        SceneManager.LoadScene("Level1");
    }

    public void Quit() {
        Debug.Log("Application Quit Called!!!");
        Application.Quit();
    }
}
