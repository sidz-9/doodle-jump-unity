using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UiController : MonoBehaviour
{
    public static UiController instance;
    public GameObject endGamePanel;
    public GameObject tapToStartText;
    public GameObject gameOverImage;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI inGameScoreText;
    public TextMeshProUGUI highScoreText;

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
        inGameScoreText.text = ScoreController.instance.score.ToString();
    }

    public void GameStart() {
        tapToStartText.SetActive(false);
        inGameScoreText.gameObject.SetActive(true);
    }
    public void GameOver() {
        inGameScoreText.gameObject.SetActive(false);
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        endGamePanel.SetActive(true);
        Debug.LogWarning("Your score is: " + PlayerPrefs.GetInt("Score"));
        Debug.LogWarning("Your high score is: " + PlayerPrefs.GetInt("HighScore"));
    }

    public void Replay() {
        SceneManager.LoadScene("Level1");
    }

    public void Quit() {
        Debug.Log("Application Quit Called!!!");
        Application.Quit();
    }
}
