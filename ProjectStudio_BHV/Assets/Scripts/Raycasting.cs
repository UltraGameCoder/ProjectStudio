using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Raycasting : MonoBehaviour {

    // HUD & Control functions
    public Camera cam;
    public GameObject crosshair;
    public Text pickupInfo;
    public GameObject pickUp;
    public GameObject objectInHand;
    public string itemName;
    private bool usableObject;

    public ScoreSystem _scoreSys;

    // Help situation
    public GameObject infoPanel;
    public GameObject personHelp;

    // Filling situation
    public GameObject tap;
    public GameObject water;
    public GameObject waterHelp;
    public bool waterBool;

    // Extinguish situation
    public GameObject bucket;
    public GameObject fireP;
    public GameObject extinguishFire;
    public GameObject fireHelp;
    private bool bucketBool;
    public bool fireBool;

    // Papier Situation
    public GameObject paper;
    public GameObject paperHelp;
    public GameObject paperDeliver;
    public GameObject cupboard;
    public bool paperBool;

    private SituationPanelScript situationPanelScript;
    private IEnumerable<Transform> hierarchy;

    // Use this for initialization
    void Start () {
        waterHelp.SetActive(false);
        water.SetActive(false);
        waterBool = false;
        usableObject = false;
        personHelp.SetActive(false);
        pickUp.SetActive(false);
        fireHelp.SetActive(false);
        extinguishFire.SetActive(false);
        paperDeliver.SetActive(false);
        paperHelp.SetActive(false);
        situationPanelScript = infoPanel.GetComponent<SituationPanelScript>();
    }

    // Update is called once per frame
    void Update()
    {
        pickupInfo.text = gameObject.tag;


        if (!areHUDSOpen())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 3))
            {
                // Help situation
                if (hit.transform.CompareTag("HurtPerson"))
                {
                    //personHelp.SetActive(true);
                    if (Input.GetKeyDown("e"))
                    {
                        HurtPersonScript person = hit.transform.gameObject.GetComponent<HurtPersonScript>();
                        if (person.done) { return; }
                        enableInfoPanel();
                        situationPanelScript.textFile = person.situation;
                        situationPanelScript.setPerson(person);
                        situationPanelScript.loadFile();
                        //personDone = true;
                    }
                    /*if(personDone == true)
                    {
                        personHelp.SetActive(false);
                    }*/
                }
                // Pick up Bucket
                else if (hit.transform.CompareTag("Bucket"))
                {
                    pickupInfo.text = "Emmer";
                    usableObject = true;
                    pickUp.SetActive(true);
                    if (Input.GetKeyDown("e"))
                    {
                        if (usableObject && objectInHand == null)
                        {
                            PutObjectInHands(hit.transform.gameObject);
                            itemName = "Bucket";
                            usableObject = false;
                        }
                    }
                    disableInfoPanel();
                }
                // Fill the bucket
                else if (hit.transform.CompareTag("Tap"))
                {
                    if (itemName == "Bucket" && waterBool == false)
                    {
                        usableObject = true;
                        waterHelp.SetActive(true);
                    }
                    if (Input.GetKeyDown("e") && usableObject && itemName == "Bucket" && waterBool == false)
                    {
                        waterHelp.SetActive(false);
                        water.SetActive(true);
                        waterBool = true;
                    }
                }

                else if (hit.transform.CompareTag("Door"))
                {
                    if (Input.GetKeyDown("e"))
                    {
                        Door d = hit.transform.GetComponent<Door>();
                        if (d.isOpen())
                        {
                            d.close();
                        }
                        else {
                            d.open();
                        }
                    }
                }
                // Deliver the bucket
                else if (hit.transform.CompareTag("Fire"))
                {
                    if (fireBool == false)
                    {
                        usableObject = true;
                        fireHelp.SetActive(true);
                    }

                    if (usableObject && itemName == "Bucket" && waterBool == true)
                    {
                        fireHelp.SetActive(false);
                        extinguishFire.SetActive(true);

                        if (Input.GetKeyDown("e"))
                        {
                            bucket.SetActive(false);
                            fireP.SetActive(false);
                            fireHelp.SetActive(false);
                            itemName = "";
                            objectInHand = null;
                            fireBool = true;
                        }

                        if (fireBool == true)
                        {
                            fireHelp.SetActive(false);
                            usableObject = false;
                            extinguishFire.SetActive(false);
                            int score = UnityEngine.Random.Range(10, 30);
                            _scoreSys.addScore(score);
                        }
                    }
                }
                // Pick up Paper
                else if (hit.transform.CompareTag("Paper"))
                {
                    pickupInfo.text = "Documenten";
                    usableObject = true;
                    pickUp.SetActive(true);
                    if (Input.GetKeyDown("e"))
                    {
                        if (usableObject && objectInHand == null)
                        {
                            PutObjectInHands(hit.transform.gameObject);
                            itemName = "Paper";
                            usableObject = false;
                        }
                    }
                    disableInfoPanel();
                }
                // Deliver Paper to .....
                else if (hit.transform.CompareTag("Cupboard"))
                {
                    if (paperBool == false)
                    {
                        usableObject = true;
                        paperHelp.SetActive(true);
                    }
                    if (usableObject && itemName == "Paper")
                    {
                        paperHelp.SetActive(false);
                        paperDeliver.SetActive(true);
                        if (Input.GetKeyDown("e"))
                        {
                            paper.SetActive(false);
                            paperDeliver.SetActive(false);
                            paperHelp.SetActive(false);
                            itemName = "";
                            objectInHand = null;
                            paperBool = true;
                        }
                        if (paperBool == true)
                        {
                            paperHelp.SetActive(false);
                            usableObject = false;
                            int score = UnityEngine.Random.Range(10, 30);
                            _scoreSys.addScore(score);
                        }
                    }
                }
                else
                {
                    waterHelp.SetActive(false);
                    pickupInfo.text = "";
                    usableObject = false;
                    personHelp.SetActive(false);
                    pickUp.SetActive(false);
                    fireHelp.SetActive(false);
                    extinguishFire.SetActive(false);
                    paperDeliver.SetActive(false);
                    paperHelp.SetActive(false);
                    disableInfoPanel();
                }
            }
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

        public void enableInfoPanel() {
            infoPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            crosshair.SetActive(false);
        }

        public void disableInfoPanel() {
            infoPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            crosshair.SetActive(true);
        }

        private void PutObjectInHands(GameObject pickUpObject)
        {
            this.objectInHand = pickUpObject;
            this.objectInHand.transform.SetParent(transform);
            this.objectInHand.transform.localPosition = new Vector3(0.485f, -0.368f, 0.768f);
            this.objectInHand.transform.localRotation = Quaternion.Euler(new Vector3(-90, 0, 0));
            this.objectInHand.GetComponent<Collider>().isTrigger = true;
            this.objectInHand.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.objectInHand.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            this.objectInHand.GetComponent<Rigidbody>().freezeRotation = true;
            this.objectInHand.GetComponent<Rigidbody>().detectCollisions = false;
            this.objectInHand.GetComponent<Rigidbody>().useGravity = false;
            //this.objectInHand.GetComponentInChildren<Light>().enabled = false;
            //this.objectInHand.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        }
    }

