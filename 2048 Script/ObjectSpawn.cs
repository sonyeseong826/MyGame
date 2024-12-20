using UnityEditor;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    // 생성 오브젝트 number값 저장
    public int[] num = { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048 };

    // 오브젝트 위치값들
    public float[] X = { -1.6039f, -0.5344f, 0.5351f, 1.6046f };
    public float[] Y = { 0.631f, -0.4378f, -1.5066f, -2.5754f };
    public int IndexX;
    public int IndexY;
    // 오브젝트 number값 Index
    public int SpawnCube;

    // 생성, 감지할 좌표
    public Vector2 targetPosition;
    // Cube 오브젝트 생성 각도
    public Quaternion spawnRotation = Quaternion.identity;
    // 생성할 Cube 오브젝트
    public GameObject Cube;

    // 오브젝트 생성 반복문 조전
    public bool TF;
    // 오브젝트 생성 했는지
    public bool spawn;
    // 오브젝트 충돌
    public Collider2D[] colliders2;

    void Start()
    {
        spawn = false;
        // 아직 추가해야 할것 :
        // 오브젝트 생성 확률 , 오브젝트 합쳐짐, 스코어 증가, 베스트 스코어, 게임 리셋, 게임 정지
        // 오브젝트 움직임시 오브젝트 생성 오류
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
            IndexX = Random.Range(0, X.Length); // 랜덤으로 X 좌표값 인덱스 저장
            IndexY = Random.Range(0, Y.Length); // 랜덤으로 Y 좌표값 인덱스 저장

            // 생성, 충돌 좌표값 지정
            targetPosition = new Vector2(X[IndexX], Y[IndexY]);
            // 특정 좌표에 오브젝트가 있는지 감지
            Collider2D[] colliders = Physics2D.OverlapCircleAll(targetPosition, 0.1f);
            colliders2 = Physics2D.OverlapCircleAll(targetPosition, 100f);


            if (colliders2.Length > 15)
            {
                Debug.Log("패배!");
                TF = false;
            }
            else
            {
                if (colliders.Length > 0)
                {
                    Debug.Log("해당 좌표에 오브젝트가 있습니다.");
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
