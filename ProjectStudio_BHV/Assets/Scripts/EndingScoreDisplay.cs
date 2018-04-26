using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScoreDisplay : MonoBehaviour {

    public Text message;
    public Text scoreText;
    public Text highScoreText;

    void FixedUpdate() {
        int score = PlayerPrefs.GetInt("score");
        int highScore = PlayerPrefs.GetInt("highScore");
        if(highScore < score) {
            highScore = score;
            message.text = "You've beaten the highscore!";
        }
        PlayerPrefs.SetInt("highScore", highScore);
        scoreText.text = "Your Score: " + score.ToString();
        highScoreText.text = "HighScore: " + highScore.ToString();
    }
}
