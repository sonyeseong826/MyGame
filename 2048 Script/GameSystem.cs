using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;

public class GameSystem : MonoBehaviour
{
    int[] num = { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048 }; // Cube오브젝트 number값

    Vector2 v2; // 큐브 이동속도
    public bool test; // 이동 반복 확인
    public Vector2 objectV2; // 이동 최대 좌표값
    Vector2 obcol; // 이동 최대 좌표 계산값
    
    public string objectName; // 닿은 오브젝트 이름
    ObjectSpawn objectSpawn; // 스크립트

    public GameObject Cube; // 생성 오브젝트
    public GameObject DeleteCube; // 제거할 큐브
    public int SpawnCube; // 생성할 큐브 이름 지정
    Vector2 spawmV2; // 오브젝트 생성 위치지정
    public Quaternion spawnRotation = Quaternion.identity;// 오브젝트 생성 각도지정


    // X : -1.6039, -0.5344, 0.5351, 1.6046 : +1.0695
    // Y : 0.631, -0.4378, -1.5066, -2.5754 : -1.0688
    void Start()
    {
        objectSpawn = FindObjectOfType<ObjectSpawn>(); // 스크립트 컴포넌트

        test = false; // 큐브 이동 반복 false로 지정
        objectSpawn.spawn = false; // 오브젝트 생성 메소드 false로 지정
    }

    void Update()
    {
        v2 = transform.position; // 현재 오브젝트 좌표 저장
        CubeMove(); // CubeMove 메서드 실행
    }

    async void CubeMove()
    {
        if(gameObject != null) // gameObject가 null이 아니라면
        {
            // 아래클릭
            if (Input.GetKeyDown(KeyCode.DownArrow) && !test)
            {
                objectSpawn.spawn = true; // 오브젝트 생성 활성화
                obcol = new Vector2(0, -1.0688f); // 좌표값 지정
                await Task.Delay(100);
                test = true; // 반복문 실행
                objectV2.y = (-2.5754f - 1.0688f); // Y값에 -1칸으로 저장
                while (test)
                {
                    v2.y -= 0.05344f; // Y값 속도 지정
                    // 현재 오브젝트 위치가 이동 최대값보다 작다면
                    if (transform.position.y <= (objectV2.y + 1.0688f) && objectV2 != null)
                    {
                        // 현재 오브젝트 위치를 지정
                        transform.position = new Vector2(transform.position.x, (objectV2.y + 1.0688f));
                        // 박복문 정지
                        test = false;
                    }
                    else
                    {
                        // 아니라면 현재 위치를 계속 이동
                        transform.position = v2;
                    }
                    await Task.Delay(1);
                }
                await Task.Delay(10);
                if(gameObject != null) // * 오류 발생
                {
                    plus();
                }
                else
                {
                    Debug.LogWarning("is null");
                }
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
                if (gameObject != null)
                {
                    plus();
                }
                else
                {
                    Debug.LogWarning("is null");
                }
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
                if (gameObject != null)
                {
                    plus();
                }
                else
                {
                    Debug.LogWarning("is null");
                }
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
            await Task.Delay(50);
            Destroy(gameObject);
            papa();
        }
        else
        {
            Debug.Log("다르다!");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null) // 닿은 오브젝트가 null이 아니라면
        {
            // 현재 오브젝트 이름이 닿은 오브젝트 이름이랑 같다면
            if(transform.name == other.transform.name)
            {
                // 닿은 오브젝트 태그 저장
                string SC = other.transform.tag;
                // 큐브 이름 number 지정
                SpawnCube = (int.Parse(SC));
                // 이동 최대값을 지정
                objectV2.x = other.gameObject.transform.position.x + obcol.x;
                objectV2.y = other.gameObject.transform.position.x + obcol.y;
                // 오브젝트 생성 위치 지정
                spawmV2 = other.gameObject.transform.position;
                // 닿은 오브젝트 이름을 지정
                objectName = other.gameObject.name;
                // 제거할 오브젝트 지정
                DeleteCube = other.gameObject;
            }
            else
            {
                // 이동 최대값 지정
                objectV2 = other.gameObject.transform.position;
                // 닿은 오브젝트 이름 지정
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
        // 특정 경로에 특정 이름을 가진 오브젝트를 Cube에 저장
        Cube = (GameObject)AssetDatabase.LoadAssetAtPath($"Assets/Objects/Cube{SpawnCube * 2}.prefab", typeof(GameObject));

        // 생성 오브젝트를 저장
        GameObject spawn = Instantiate(Cube, spawmV2, spawnRotation);
        // 생성 오브젝트 이름 지정
        string name = $"Cube {(SpawnCube * 2).ToString()}";

        // 생성 오브젝트 이름 변경
        spawn.name = name;
    }
}
