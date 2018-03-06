using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    Vector2 mouseS;
    Vector2 smooth;

    public float turnSpd;
    public float smoothing;

    GameObject character;

    void Start()
    {

        character = this.transform.parent.gameObject;
    }

    void Update()
    {
        var mouseD = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseD = Vector2.Scale(mouseD, new Vector2(turnSpd * smoothing, turnSpd * smoothing));
        smooth.x = Mathf.Lerp(smooth.x, mouseD.x, 1.0f / smoothing);
        smooth.y = Mathf.Lerp(smooth.y, mouseD.y, 1.0f / smoothing);
        mouseS += smooth;

       mouseS.y = Mathf.Clamp(mouseS.y, -90.0f, 90.0f);

        transform.localRotation = Quaternion.AngleAxis(-mouseS.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseS.x, character.transform.up);
    }
}
