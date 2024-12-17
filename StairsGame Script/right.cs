using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class right : MonoBehaviour
{
    PlayerMove pm;
    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        pm.EVE();
    }
}
