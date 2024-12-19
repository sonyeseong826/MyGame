using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;
using TMPro.Examples;
using System.Diagnostics.Tracing;
using TMPro;
using Unity.VisualScripting;

public class GameSystem : MonoBehaviour
{
    int[] num = { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048 };

    Vector2 v2;
    public bool test;

    public bool Coll;
    public Vector2 objectV2;
    public string objectName;

    ObjectSpawn objectSpawn;
    GameSystem gameSystem;
    public Quaternion spawnRotation = Quaternion.identity;
    Vector2 obcol;

    public GameObject Cube;
    public int SpawnCube;
    public GameObject DeleteCube;
    Vector2 spawmV2;

    // X : -1.6039, -0.5344, 0.5351, 1.6046 : +1.0695
    // Y : 0.631, -0.4378, -1.5066, -2.5754 : -1.0688

    int Count;
    void Start()
    {
        objectSpawn = FindObjectOfType<ObjectSpawn>();

        test = false;
        objectSpawn.spawn = false;
        Coll = false;
    }

    // Update is called once per frame
    void Update()
    {
        v2 = transform.position;
        CubeMove();
    }

    async void CubeMove()
    {
        if(gameObject != null)
        {
            // 아래클릭
            if (Input.GetKeyDown(KeyCode.DownArrow) && !test)
            {
                objectSpawn.spawn = true;
                obcol = new Vector2(0, -1.0688f);
                await Task.Delay(100);
                test = true;
                objectV2.y = (-2.5754f - 1.0688f);
                while (test)
                {
                    v2.y -= 0.05344f;
                    if (transform.position.y <= (objectV2.y + 1.0688f) && objectV2 != null)
                    {
                        transform.position = new Vector2(transform.position.x, (objectV2.y + 1.0688f));
                        test = false;
                    }
                    else
                    {
                        transform.position = v2;
                    }
                    await Task.Delay(1);
                }
                await Task.Delay(10);
                plus();
            }
            // 위클릭
            else if (Input.GetKeyDown(KeyCode.UpArrow) && !test)
            {
                objectSpawn.spawn = true;
                obcol = new Vector2(0, 1.0688f);
                await Task.Delay(100);
                test = true;
                objectV2.y = (0.631f + 1.0688f);
                while (test)
                {
                    v2.y += 0.05344f;
                    if (transform.position.y >= (objectV2.y - 1.0688f) && objectV2 != null)
                    {
                        transform.position = new Vector2(transform.position.x, (objectV2.y - 1.0688f));
                        test = false;
                    }
                    else
                    {
                        transform.position = v2;
                    }
                    await Task.Delay(1);
                }
                await Task.Delay(10);
                plus();
            }
            // 오른쪽 클릭
            else if (Input.GetKeyDown(KeyCode.RightArrow) && !test)
            {
                objectSpawn.spawn = true;
                obcol = new Vector2(1.0695f, 0);
                await Task.Delay(100);
                test = true;
                objectV2.x = (1.6046f + 1.0695f);
                while (test)
                {
                    v2.x += 0.053475f;
                    if (transform.position.x >= (objectV2.x - 1.0695f) && objectV2 != null)
                    {
                        transform.position = new Vector2((objectV2.x - 1.0695f), transform.position.y);
                        test = false;
                    }
                    else
                    {
                        transform.position = v2;
                    }
                    await Task.Delay(1);
                }
                await Task.Delay(10);
                plus();
            }
            // 왼쪽 클릭
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && !test)
            {
                objectSpawn.spawn = true;
                obcol = new Vector2(-1.0695f, 0);
                await Task.Delay(100);
                test = true;
                objectV2.x = (-1.6039f - 1.0695f);
                while (test)
                {
                    v2.x -= 0.053475f;
                    if (transform.position.x <= (objectV2.x + 1.0695f) && objectV2 != null)
                    {
                        transform.position = new Vector2((objectV2.x + 1.0695f), transform.position.y);
                        test = false;
                    }
                    else
                    {
                        transform.position = v2;
                    }
                    await Task.Delay(1);
                }
                await Task.Delay(10);
                plus();
            }
        }
        else
        {
            Debug.LogWarning("객체 제거");
        }
    }

    async void plus()
    {
        if(objectName == transform.name)
        {
            Debug.Log(objectName+"같다!");
            Destroy(DeleteCube);
            objectName = null;
            papa();
            await Task.Delay(1000);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null)
        {
            Debug.Log("닿았다");
            Coll = true;
            if(transform.name == other.transform.name)
            {
                string SC = other.transform.tag;
                SpawnCube = (int.Parse(SC));
                Debug.Log(SpawnCube);
                objectV2.x = other.gameObject.transform.position.x + obcol.x;
                objectV2.y = other.gameObject.transform.position.x + obcol.y;
                spawmV2 = other.gameObject.transform.position;
                objectName = other.gameObject.name;
                DeleteCube = other.gameObject;
            }
            else
            {
                objectV2 = other.gameObject.transform.position;
                objectName = other.gameObject.name;
            }
        }
        else
        {
            Debug.Log("없다!");
        }
    }

    void papa()
    {
        Cube = (GameObject)AssetDatabase.LoadAssetAtPath($"Assets/Objects/Cube{SpawnCube * 2}.prefab", typeof(GameObject));

        GameObject spawn = Instantiate(Cube, spawmV2, spawnRotation);
        string name = $"Cube {(SpawnCube * 2).ToString()}";

        Debug.Log(spawmV2);
        spawn.name = name;
    }
}
