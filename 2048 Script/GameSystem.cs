using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;

public class GameSystem : MonoBehaviour
{
    int[] num = { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048 }; // Cube������Ʈ number��

    Vector2 v2; // ť�� �̵��ӵ�
    public bool test; // �̵� �ݺ� Ȯ��
    public Vector2 objectV2; // �̵� �ִ� ��ǥ��
    Vector2 obcol; // �̵� �ִ� ��ǥ ��갪
    
    public string objectName; // ���� ������Ʈ �̸�
    ObjectSpawn objectSpawn; // ��ũ��Ʈ

    public GameObject Cube; // ���� ������Ʈ
    public GameObject DeleteCube; // ������ ť��
    public int SpawnCube; // ������ ť�� �̸� ����
    Vector2 spawmV2; // ������Ʈ ���� ��ġ����
    public Quaternion spawnRotation = Quaternion.identity;// ������Ʈ ���� ��������


    // X : -1.6039, -0.5344, 0.5351, 1.6046 : +1.0695
    // Y : 0.631, -0.4378, -1.5066, -2.5754 : -1.0688
    void Start()
    {
        objectSpawn = FindObjectOfType<ObjectSpawn>(); // ��ũ��Ʈ ������Ʈ

        test = false; // ť�� �̵� �ݺ� false�� ����
        objectSpawn.spawn = false; // ������Ʈ ���� �޼ҵ� false�� ����
    }

    void Update()
    {
        v2 = transform.position; // ���� ������Ʈ ��ǥ ����
        CubeMove(); // CubeMove �޼��� ����
    }

    async void CubeMove()
    {
        if(gameObject != null) // gameObject�� null�� �ƴ϶��
        {
            // �Ʒ�Ŭ��
            if (Input.GetKeyDown(KeyCode.DownArrow) && !test)
            {
                objectSpawn.spawn = true; // ������Ʈ ���� Ȱ��ȭ
                obcol = new Vector2(0, -1.0688f); // ��ǥ�� ����
                await Task.Delay(100);
                test = true; // �ݺ��� ����
                objectV2.y = (-2.5754f - 1.0688f); // Y���� -1ĭ���� ����
                while (test)
                {
                    v2.y -= 0.05344f; // Y�� �ӵ� ����
                    // ���� ������Ʈ ��ġ�� �̵� �ִ밪���� �۴ٸ�
                    if (transform.position.y <= (objectV2.y + 1.0688f) && objectV2 != null)
                    {
                        // ���� ������Ʈ ��ġ�� ����
                        transform.position = new Vector2(transform.position.x, (objectV2.y + 1.0688f));
                        // �ں��� ����
                        test = false;
                    }
                    else
                    {
                        // �ƴ϶�� ���� ��ġ�� ��� �̵�
                        transform.position = v2;
                    }
                    await Task.Delay(1);
                }
                await Task.Delay(10);
                if(gameObject != null) // * ���� �߻�
                {
                    plus();
                }
                else
                {
                    Debug.LogWarning("is null");
                }
            }
            // ��Ŭ��
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
                if (gameObject != null)
                {
                    plus();
                }
                else
                {
                    Debug.LogWarning("is null");
                }
            }
            // ������ Ŭ��
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
                if (gameObject != null)
                {
                    plus();
                }
                else
                {
                    Debug.LogWarning("is null");
                }
            }
            // ���� Ŭ��
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
                if (gameObject != null)
                {
                    plus();
                }
                else
                {
                    Debug.LogWarning("null");
                }
            }
        }
        else
        {
            Debug.LogWarning("��ü ����");
        }
    }

    async void plus()
    {
        if(objectName == transform.name)
        {
            Debug.Log(objectName+"����!");
            Destroy(DeleteCube);
            objectName = null;
            await Task.Delay(50);
            Destroy(gameObject);
            papa();
        }
        else
        {
            Debug.Log("�ٸ���!");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null) // ���� ������Ʈ�� null�� �ƴ϶��
        {
            // ���� ������Ʈ �̸��� ���� ������Ʈ �̸��̶� ���ٸ�
            if(transform.name == other.transform.name)
            {
                // ���� ������Ʈ �±� ����
                string SC = other.transform.tag;
                // ť�� �̸� number ����
                SpawnCube = (int.Parse(SC));
                // �̵� �ִ밪�� ����
                objectV2.x = other.gameObject.transform.position.x + obcol.x;
                objectV2.y = other.gameObject.transform.position.x + obcol.y;
                // ������Ʈ ���� ��ġ ����
                spawmV2 = other.gameObject.transform.position;
                // ���� ������Ʈ �̸��� ����
                objectName = other.gameObject.name;
                // ������ ������Ʈ ����
                DeleteCube = other.gameObject;
            }
            else
            {
                // �̵� �ִ밪 ����
                objectV2 = other.gameObject.transform.position;
                // ���� ������Ʈ �̸� ����
                objectName = other.gameObject.name;
            }
        }
        else
        {
            Debug.Log("����!");
        }
    }

    void papa()
    {
        // Ư�� ��ο� Ư�� �̸��� ���� ������Ʈ�� Cube�� ����
        Cube = (GameObject)AssetDatabase.LoadAssetAtPath($"Assets/Objects/Cube{SpawnCube * 2}.prefab", typeof(GameObject));

        // ���� ������Ʈ�� ����
        GameObject spawn = Instantiate(Cube, spawmV2, spawnRotation);
        // ���� ������Ʈ �̸� ����
        string name = $"Cube {(SpawnCube * 2).ToString()}";

        // ���� ������Ʈ �̸� ����
        spawn.name = name;
    }
}
