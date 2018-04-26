using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Control : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 5.0F;
    [SerializeField]
    private float maxAngularVelocity = 0;
    [SerializeField]
    private float timer = 0;
    [SerializeField]
    private int answerGiven = 0;
    [SerializeField]
    private GameObject check;
    [SerializeField]
    private GameObject cross;

    CharacterController charControl;

    void Start()
    {
        cross.SetActive(false);
        check.SetActive(false);
        charControl = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (answerGiven == 1)
        {
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                check.SetActive(false);
                cross.SetActive(false);
                answerGiven = 0;
                timer = 0;
            }
        }

        if (!AreHUDSOpen() && !ArePauseOpen())
        {
            MovePlayer();
        } 
    }

    void MovePlayer()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 moveDirSide = transform.right * horiz * walkSpeed * Time.deltaTime;
        Vector3 moveDirForward = transform.forward * vert * walkSpeed * Time.deltaTime;

        charControl.SimpleMove(moveDirSide);
        charControl.SimpleMove(moveDirForward);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            walkSpeed *= 3;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            walkSpeed /= 3;
        }
    }

    public static bool AreHUDSOpen()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("HUDElement");
        foreach (GameObject obj in objects)
        {
            if (obj.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    public static bool ArePauseOpen()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("IgPauseMenu");

        foreach (GameObject obj in objects)
        {
            if (obj.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    public void showResult(bool correct)
    {
        {
            if (correct)
            {
                cross.SetActive(false);
                check.SetActive(true);
                answerGiven = 1;
            }
            else if (!correct)
            { 
                check.SetActive(false);
                cross.SetActive(true);
                answerGiven = 1;
                }
        }
    }
}