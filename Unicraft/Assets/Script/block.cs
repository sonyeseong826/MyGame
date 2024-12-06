using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class block : MonoBehaviour
{
    public float rayLength = 5;
    public float maxDistance = 5;

    public GameObject objectSpawn;
    public Vector3 spawnPosition;
    public Quaternion spawnRotation = Quaternion.identity;
    float x , y, z;
    GameObject gameObject;
    Transform hitTransform;
    Vector3 normal;

    private void Start()
    {
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, rayLength))
        {
            hitTransform = hit.transform;
            gameObject = hit.collider.gameObject;
            normal = hit.normal;
        }
        else
        {
            hitTransform = null;
            gameObject = null;
            normal = Vector3.zero;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (objectSpawn != null)
            {

                if (normal == Vector3.right)
                {
                    x = hitTransform.position.x + 1;
                    y = hitTransform.position.y;
                    z = hitTransform.position.z;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                }
                else if (normal == Vector3.left)
                {
                    x = hitTransform.position.x - 1;
                    y = hitTransform.position.y;
                    z = hitTransform.position.z;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                }
                else if (normal == Vector3.up)
                {
                    x = hitTransform.position.x;
                    y = hitTransform.position.y + 1;
                    z = hitTransform.position.z;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                }
                else if (normal == Vector3.down)
                {
                    x = hitTransform.position.x;
                    y = hitTransform.position.y - 1;
                    z = hitTransform.position.z;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                }
                else if (normal == Vector3.forward)
                {
                    x = hitTransform.position.x;
                    y = hitTransform.position.y;
                    z = hitTransform.position.z + 1;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                }
                else if (normal == Vector3.back)
                {
                    x = hitTransform.position.x;
                    y = hitTransform.position.y;
                    z = hitTransform.position.z - 1;

                    spawnPosition = new Vector3(x, y, z);

                    Instantiate(objectSpawn, spawnPosition, spawnRotation);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
