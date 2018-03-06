using UnityEngine;

public class Control : MonoBehaviour
{

    public float walkSpeed = 5.0F;

    void Start()
    {

    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * walkSpeed;
        float straffe = Input.GetAxis("Horizontal") * walkSpeed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            walkSpeed += 5;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            walkSpeed -= 5;
        }

    }
}