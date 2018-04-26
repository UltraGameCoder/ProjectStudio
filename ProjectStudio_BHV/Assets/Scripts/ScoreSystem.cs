using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreSystem : MonoBehaviour {

    private int score = 0;
    public Text scoreText;
    public Text doneText;
    public Raycasting objectSituation;
    public bool allFinished = false;

    void Start () {

	}
	
	// Update is called once per second
	void FixedUpdate () {
        if(scoreText) {
            scoreText.text = "Score: " + score.ToString();
        }
        if(doneText) {
            GameObject[] situations = GameObject.FindGameObjectsWithTag("HurtPerson");
            int done = 0;
            int total = situations.Length;
            //Count every extra situation
            done += (objectSituation.fireBool) ? 1 : 0;
            done += (objectSituation.paperBool) ? 1 : 0;
            total += 2;//Total extra situation added to hurt person count
            foreach (GameObject situation in situations) {
                HurtPersonScript person = situation.GetComponent<HurtPersonScript>();
                if(person.done) {
                    done++;
                }
            }
            doneText.text = "Done: " + done.ToString() + "/" + total.ToString();
            allFinished = (done >= total);
        }
    }

    public void addScore(int amount) {
        score += amount;
    }

    public void removeScore(int amount) {
        if((score -= amount) < 0) {
            score = 0;
        }
    }

    public int getScore() {
        return score;
    }


}
