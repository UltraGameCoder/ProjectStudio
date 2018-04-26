using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class AnsweringButton : MonoBehaviour
{
    public GameObject player;
    public int id = 0;
    public SituationPanelScript sps;
    private ScoreSystem scoreSys;
    public Raycasting raySys;


    void Start()
    {
        scoreSys = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreSystem>();
    }

    public void checkAnswer() {
        //var stopwatch = new System.Diagnostics.Stopwatch();
        int score = Random.Range(10, 30);
        var p = player.GetComponent<Control>();

        if (sps.getPerson().state == QuestionState.FIRST)
        {
            int answer = sps.getRightAnswer();
            if(id == answer) {
                print("Choosen first right answer! +" + score.ToString());
                p.showResult(true);
                sps.nextState();
                raySys.disableInfoPanel();
            } else {
                print("Choosen first wrong answer! -" + score.ToString());
                p.showResult(false);
                scoreSys.removeScore(score);
                raySys.enableInfoPanel();
            }

        }
        else if(sps.getPerson().state == QuestionState.SECOND)
        {
            int answer = sps.getRightAnswer();
            if(id == answer) {
                print("Choosen second right answer! +" + score.ToString());
                p.showResult(true);
                scoreSys.addScore(score);
                sps.getPerson().done = true;
                raySys.disableInfoPanel();
            } else {
                print("Choosen second wrong answer! -" + score.ToString());
                p.showResult(false);
                scoreSys.removeScore(score);
                raySys.enableInfoPanel();
            }
        }
    }
}
