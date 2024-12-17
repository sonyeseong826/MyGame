using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public GameObject StairsObject; // ���� ������Ʈ
    public Vector2 SpawnPosition; // ������Ʈ ���� ��ġ
    public Quaternion SpawnRotation = Quaternion.identity; // ������Ʈ ���� ����
    public string name; // ���� ������Ʈ �̸�
    public int count = 0; // ������Ʈ ���� ����

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
                // ������ ������Ʈ, ��ġ, ���� ����
                GameObject spawn = Instantiate(StairsObject, SpawnPosition, SpawnRotation);
                // ������ ������Ʈ �̸� ����
                name = $"Stairs {count.ToString()}";
                // ������Ʈ �̸��� �����Ͽ� ����
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
                // ������ ������Ʈ, ��ġ, ���� ����
                GameObject spawn = Instantiate(StairsObject, SpawnPosition, SpawnRotation);
                // ������ ������Ʈ �̸� ����
                name = $"Stairs {count.ToString()}";
                // ������Ʈ �̸��� �����Ͽ� ����
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
                // ������ ������Ʈ, ��ġ, ���� ����
                GameObject spawn = Instantiate(StairsObject, SpawnPosition, SpawnRotation);
                // ������ ������Ʈ �̸� ����
                name = $"Stairs {count.ToString()}";
                // ������Ʈ �̸��� �����Ͽ� ����
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
                // ������ ������Ʈ, ��ġ, ���� ����
                GameObject spawn = Instantiate(StairsObject, SpawnPosition, SpawnRotation);
                // ������ ������Ʈ �̸� ����
                name = $"Stairs {count.ToString()}";
                // ������Ʈ �̸��� �����Ͽ� ����
                spawn.name = name;
                TF = true;
                UpCount = 0;
            }
        }
    }
}
