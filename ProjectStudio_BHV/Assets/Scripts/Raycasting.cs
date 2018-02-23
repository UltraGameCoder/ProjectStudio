using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour {

   public Camera cam;
    public GameObject infoPanel;


	// Use this for initialization
	void Start () {
        infoPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 3))
            {
                if (hit.transform.CompareTag("HurtPerson"))
                {
                    infoPanel.SetActive(true);
                }
                else
                {
                    infoPanel.SetActive(false);
                }
                print("I'm looking at " + hit.transform.name);
            }
            else
            {
                infoPanel.SetActive(false);
                print("I'm looking at nothing!");
            }
        }
    }
}
