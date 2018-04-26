using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour {

    public ScoreSystem scoreSys;
    public GameObject effect;

    private void OnCollisionEnter(Collision col)
    {
        if(!helpedAll()) {
            return;
        }
        print("COLLISION DETECTED WIDTH: "+ col.gameObject.tag.ToString());
        if (col.gameObject.CompareTag("Player"))
        {
            int score = scoreSys.getScore();
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameEnding");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
        }
    }

    private void FixedUpdate() {
        if(helpedAll()) {
            effect.SetActive(true);
        } else {
            effect.SetActive(false);
        }
    }

    private bool helpedAll() {
        //New code
        return scoreSys.allFinished;

        /*
        //Old backup code
        GameObject[] situations = GameObject.FindGameObjectsWithTag("HurtPerson");

        foreach(GameObject situation in situations) {
            HurtPersonScript person = situation.GetComponent<HurtPersonScript>();
            if(!person.done) {
                return false;
            }
        }

        return true;
        */
    }


}
