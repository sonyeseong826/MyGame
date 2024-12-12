using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InvenTab : MonoBehaviour
{
    public GameObject UI;
    public bool game;
    void Start()
    {
        UI.gameObject.SetActive(false);
        game = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!game)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                UI.gameObject.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                game = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UI.gameObject.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                game = false;
            }
        }
    }
}
