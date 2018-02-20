using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contoll : MonoBehaviour {

    public int rotateSpeed;
    public int walkSpeed;

	void Start () {
		
	}

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * walkSpeed;
        

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}