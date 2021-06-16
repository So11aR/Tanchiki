using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timer;
    private GameObject obj;

    public float spawnTime = 5f;
    public GameObject[] objects;

    void Update()
    {
        if (!obj)
        {
            timer += Time.deltaTime;
            if (timer >= spawnTime)
            {
                timer = 0;
                obj = objects[Random.Range(0, objects.Length)];
                obj = Instantiate(obj, transform.position, obj.transform.rotation);
            }
        }
    }
}
