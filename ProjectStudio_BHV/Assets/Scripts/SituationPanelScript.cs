using UnityEngine;
using UnityEngine.UI;

public class SituationPanelScript : MonoBehaviour {


    public Text question;
    public Text[] answers;

	// Use this for initialization
	void Start () {
        question.text = "Vraag";
        answers[0].text = "Antwoord 1";
        answers[1].text = "Antwoord 2";
        answers[2].text = "Antwoord 3";
        answers[3].text = "Antwoord 4";
    }
	
	// Update is called once per frame
	void Update () {


    }
}
