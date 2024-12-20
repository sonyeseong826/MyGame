using UnityEditor;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    // ���� ������Ʈ number�� ����
    public int[] num = { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048 };

    // ������Ʈ ��ġ����
    public float[] X = { -1.6039f, -0.5344f, 0.5351f, 1.6046f };
    public float[] Y = { 0.631f, -0.4378f, -1.5066f, -2.5754f };
    public int IndexX;
    public int IndexY;
    // ������Ʈ number�� Index
    public int SpawnCube;

    // ����, ������ ��ǥ
    public Vector2 targetPosition;
    // Cube ������Ʈ ���� ����
    public Quaternion spawnRotation = Quaternion.identity;
    // ������ Cube ������Ʈ
    public GameObject Cube;

    // ������Ʈ ���� �ݺ��� ����
    public bool TF;
    // ������Ʈ ���� �ߴ���
    public bool spawn;
    // ������Ʈ �浹
    public Collider2D[] colliders2;

    void Start()
    {
        spawn = false;
        // ���� �߰��ؾ� �Ұ� :
        // ������Ʈ ���� Ȯ�� , ������Ʈ ������, ���ھ� ����, ����Ʈ ���ھ�, ���� ����, ���� ����
        // ������Ʈ �����ӽ� ������Ʈ ���� ����
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            CubeSpawn();
        }
        else
        {
           
        }
    }
    public void CubeSpawn()
    {
        TF = true;

        while (TF)
        {
            IndexX = Random.Range(0, X.Length); // �������� X ��ǥ�� �ε��� ����
            IndexY = Random.Range(0, Y.Length); // �������� Y ��ǥ�� �ε��� ����

            // ����, �浹 ��ǥ�� ����
            targetPosition = new Vector2(X[IndexX], Y[IndexY]);
            // Ư�� ��ǥ�� ������Ʈ�� �ִ��� ����
            Collider2D[] colliders = Physics2D.OverlapCircleAll(targetPosition, 0.1f);
            colliders2 = Physics2D.OverlapCircleAll(targetPosition, 100f);


            if (colliders2.Length > 15)
            {
                Debug.Log("�й�!");
                TF = false;
            }
            else
            {
                if (colliders.Length > 0)
                {
                    Debug.Log("�ش� ��ǥ�� ������Ʈ�� �ֽ��ϴ�.");
                }
                else
                {
                    SpawnCube = Random.Range(0, 5);

                    Cube = (GameObject)AssetDatabase.LoadAssetAtPath($"Assets/Objects/Cube{num[SpawnCube]}.prefab", typeof(GameObject));

                    GameObject spawn = Instantiate(Cube, targetPosition, spawnRotation);
                    string name = $"Cube {num[SpawnCube].ToString()}";

                    spawn.name = name;

                    TF = false;
                }
            }
        }
    }
}
