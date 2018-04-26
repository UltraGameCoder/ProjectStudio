using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class circletemp : MonoBehaviour {

    Image renderer;
    bool isClicked = false;
	void Start () {
        renderer = this.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        float mousePosx = Input.mousePosition.x;
        float mousePosy = Input.mousePosition.y;

        if ( mousePosx > this.transform.position.x && mousePosx < this.transform.position.x + this.renderer.rectTransform.rect.width) {
            if (mousePosy > this.transform.position.y && mousePosy < this.transform.position.y + this.renderer.rectTransform.rect.height) {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!isClicked)
                    {
                        this.renderer.color = Color.red;
                        isClicked = true;
                    }
                    else
                    {
                        this.renderer.color = Color.white;
                        isClicked = false;
                    }
                }
            }
        }
	}
}
