using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Raycasting : MonoBehaviour {

    public Camera cam;
    public GameObject infoPanel;
    public GameObject crosshair;


    // Use this for initialization
    void Start () {
        infoPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.Z)) { 
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKey(KeyCode.X))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }


        if (Input.GetMouseButtonDown(0) && !areHUDSOpen())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;


            if (Physics.Raycast(ray, out hit, 3))
            {
                if (hit.transform.CompareTag("HurtPerson"))
                {
                    infoPanel.SetActive(true);
                    crosshair.SetActive(false);

                }
                else
                {
                    infoPanel.SetActive(false);
                    crosshair.SetActive(true);
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.lockState = CursorLockMode.Confined;
                }
                print("I'm looking at " + hit.transform.name);
            }
            else
            {
                infoPanel.SetActive(false);
                crosshair.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.lockState = CursorLockMode.Confined;
                print("I'm looking at nothing!");
            }
        }
        if (infoPanel.activeSelf && Input.GetKeyDown(KeyCode.Mouse1)) {
            infoPanel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            crosshair.SetActive(true);
        }

        if (infoPanel.activeSelf && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Cursor.visible = true;
        }

        if (!infoPanel.activeSelf && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Cursor.visible = false;
        }


    }

    private bool areHUDSOpen() {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("HUDElement");

        foreach (GameObject obj in objects) {
            if (obj.activeSelf) {
                return true;
            }
        }
        return false;
    }
}
