using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pausepopup;
    public GameObject crosshair;
    public GameObject score;

    // Use this for initialization
    void Start()
    {
        pausepopup.SetActive(false);
    }

    public void Close()
    {
        //score.SetActive(true);
        pausepopup.SetActive(false);
        crosshair.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.P))
        {
 
            if (!pausepopup.activeSelf)
            {
                //score.SetActive(false);
                pausepopup.SetActive(true);
                crosshair.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                //score.SetActive(true);
                pausepopup.SetActive(false);
                crosshair.SetActive(true);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
