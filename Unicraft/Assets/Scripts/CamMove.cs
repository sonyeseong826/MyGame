using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public GameObject head;
    public bool person = false;

    void Start()
    {
        cam1.gameObject.SetActive(true);
        cam2.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            person = !person;

            cam1.gameObject.SetActive(!person);
            cam2.gameObject.SetActive(person);


        }
            
        if (person)
        {
            head.SetActive(true);
        }
        else
        {
            head.SetActive(false);
        }
    }
}
