using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sphere : MonoBehaviour
{
    public Vector2 Max = new Vector2(0.5f, 0.5f);
    public Vector2 Min = new Vector2(-0.5f, -0.5f);

    Game game;



    private void Start()
    {
        game = FindObjectOfType<Game>();
    }

    private void OnMouseDown()
    {
        if (game.IsGame)
        {
            StartCoroutine(MoveRandomly());
        }
        else
        {
            return;
        }
    }

    private IEnumerator MoveRandomly()
    {
        for (int i = 0; i < 5; i++)
        {
            float RandomX = Random.Range(Max.x, Min.x);
            float RandomY = Random.Range(Max.y, Min.y);

            transform.position = new Vector2(RandomX, RandomY);
            yield return new WaitForSeconds(0.01f);
        }
        transform.position = new Vector2(0, 0);
        game.Count();
    }
}
