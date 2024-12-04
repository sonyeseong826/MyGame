using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private int count = 0;
    public TextMeshPro COUNT;

    private float Timer = 10f;
    public Text time;

    public TextMeshPro text;
    public GameObject TimeOver;

    public bool IsGame = true;
    void Start()
    {
        TimeOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer > 0)
        {
            Timer -= Time.deltaTime;
            time.text = string.Format("{0:N2}", Timer);
            Debug.Log(Timer);
        }
        else
        {
            Time.timeScale = 0f;
            Timer = 0f;
            TimeOver.SetActive(true);
            IsGame = false;
        }
    }

    public void Count()
    {
        count++;
        text.text = "SCORE : " + count;
        COUNT.text = count.ToString();
    }
}
