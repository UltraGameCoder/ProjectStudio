using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    public int walkSpeed;

    public float hSpeed = 2.0f;
    public float vSpeed = 2.0f;

    private float hSight = 0.0f;
    private float vSight = 0.0f;

    void Update()
    {
  
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * walkSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * walkSpeed;
        }
  
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        hSight += hSpeed * Input.GetAxis("Mouse X");
        vSight -= vSpeed * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(vSight, hSight, 0.0f);

    }
}
