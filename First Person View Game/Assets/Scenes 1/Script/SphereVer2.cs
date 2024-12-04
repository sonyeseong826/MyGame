using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereVer2 : MonoBehaviour
{
    public Vector3 Max = new Vector3(3.5f, 0.7f, 7.5f);
    public Vector3 Min = new Vector3(-3.5f, 5.3f, 7.5f);

    bool IsGame = true;

    Game game;
    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsGame) return;
    }

    private void OnMouseDown()
    {
        if (IsGame == true)
        {
            float RandomX = Random.Range(Max.x, Min.x);
            float RandomY = Random.Range(Max.y, Min.y);

            transform.position = new Vector3(RandomX, RandomY, 7.5f);

            game.Scores();
        }
    }

    public void TimeOver()
    {
        IsGame = false;
    }
}
