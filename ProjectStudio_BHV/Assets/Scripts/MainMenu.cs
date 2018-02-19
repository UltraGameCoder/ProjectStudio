using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject Menu;
    public GameObject Credits;

    void Start () {
        Credits.SetActive(false);
    }

    public void LoadGame() {
        SceneManager.LoadScene("Game");
    }

    public void Quit() {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
                Application.Quit ();
    #endif
    }

    public void LoadMainMenu() {
        Menu.SetActive(true);
        Credits.SetActive(false);
    }

    public void LoadCredits()
    {
        Menu.SetActive(false);
        Credits.SetActive(true);
    }
}
