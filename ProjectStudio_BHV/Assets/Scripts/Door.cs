using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    private bool _isOpen;
    private bool _isOpenFlipped;
    private float rotation = -90;
    private float rotationF = 90;

    public bool isOpen() {
        return _isOpen;
    }
    public bool isOpenFlipped()
    {
        return _isOpenFlipped;
    }

    public void open() {
        _isOpen = true;
        transform.Rotate(0,0,-rotation);
        transform.position = new Vector3(transform.position.x - 0.4f, transform.position.y, transform.position.z - 0.4f);

    }

    public void close() {
        _isOpen = false;
        transform.Rotate(0, 0, rotation);
        transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z + 0.4f);
    }
    public void openFlipped()
    {
        _isOpenFlipped = true;
        transform.Rotate(0, 0, +rotation);
        transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z + 0.4f);

    }

    public void closeFlipped()
    {
        _isOpenFlipped = false;
        transform.Rotate(0, 0, -rotation);
        transform.position = new Vector3(transform.position.x - 0.4f, transform.position.y, transform.position.z - 0.4f);
    }

}
