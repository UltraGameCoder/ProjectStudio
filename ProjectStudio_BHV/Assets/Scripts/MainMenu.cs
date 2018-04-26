using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject Menu;
    public GameObject Credits;
    public GameObject Helpscreen;

    void Start () {
        Helpscreen.SetActive(false);
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
        Helpscreen.SetActive(false);
        Menu.SetActive(true);
        Credits.SetActive(false);
    }

    public void LoadCredits()
    {
        Helpscreen.SetActive(false);
        Menu.SetActive(false);
        Credits.SetActive(true);
    }

    public void LoadHelp()
    {
        Helpscreen.SetActive(true);
        Menu.SetActive(false);
        Credits.SetActive(false);
    }
}
