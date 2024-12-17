using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public GameObject StairsObject; // 생성 오브젝트
    public Vector2 SpawnPosition; // 오브젝트 생성 위치
    public Quaternion SpawnRotation = Quaternion.identity; // 오브젝트 생성 각도
    public string name; // 현재 오브젝트 이름
    public int count = 0; // 오브젝트 생성 갯수

    public int UpCount;
    public bool TF;

    public float X;
    public float Y;

    // Start is called before the first frame update
    void Start()
    {
        UpCount = 0;

        TF = true;

        name = "Stairs 0";
        StairsObject = GameObject.Find(name);

        X = StairsObject.transform.position.x + 0.8f;
        Y = StairsObject.transform.position.y + 0.4f;

        SpawnPosition = new Vector2(X, Y);

        for (int i = 0; i < 20; i++)
        {
            StairsSpawn();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StairsSpawn()
    {
        int a = Random.Range(1, 5);

        if (TF)
        {
            if (a < 4 && UpCount < 5)
            {
                count++;
                StairsObject = GameObject.Find(name);

                X = StairsObject.transform.position.x + 0.8f;
                Y = StairsObject.transform.position.y + 0.4f;

                SpawnPosition = new Vector2(X, Y);
                // 생성할 오브젝트, 위치, 각도 지정
                GameObject spawn = Instantiate(StairsObject, SpawnPosition, SpawnRotation);
                // 생성할 오브젝트 이름 설정
                name = $"Stairs {count.ToString()}";
                // 오브젝트 이름을 변경하여 생성
                spawn.name = name;
                UpCount++;
            }
            else
            {
                count++;
                StairsObject = GameObject.Find(name);

                X = StairsObject.transform.position.x - 0.8f;
                Y = StairsObject.transform.position.y + 0.4f;

                SpawnPosition = new Vector2(X, Y);
                // 생성할 오브젝트, 위치, 각도 지정
                GameObject spawn = Instantiate(StairsObject, SpawnPosition, SpawnRotation);
                // 생성할 오브젝트 이름 설정
                name = $"Stairs {count.ToString()}";
                // 오브젝트 이름을 변경하여 생성
                spawn.name = name;
                TF = false;
                UpCount = 0;
            }
        }
        else
        {
            if (a < 4 && UpCount < 5)
            {
                count++;
                StairsObject = GameObject.Find(name);

                X = StairsObject.transform.position.x - 0.8f;
                Y = StairsObject.transform.position.y + 0.4f;

                SpawnPosition = new Vector2(X, Y);
                // 생성할 오브젝트, 위치, 각도 지정
                GameObject spawn = Instantiate(StairsObject, SpawnPosition, SpawnRotation);
                // 생성할 오브젝트 이름 설정
                name = $"Stairs {count.ToString()}";
                // 오브젝트 이름을 변경하여 생성
                spawn.name = name;
                UpCount++;
            }
            else
            {
                count++;
                StairsObject = GameObject.Find(name);

                X = StairsObject.transform.position.x + 0.8f;
                Y = StairsObject.transform.position.y + 0.4f;

                SpawnPosition = new Vector2(X, Y);
                // 생성할 오브젝트, 위치, 각도 지정
                GameObject spawn = Instantiate(StairsObject, SpawnPosition, SpawnRotation);
                // 생성할 오브젝트 이름 설정
                name = $"Stairs {count.ToString()}";
                // 오브젝트 이름을 변경하여 생성
                spawn.name = name;
                TF = true;
                UpCount = 0;
            }
        }
    }
}
