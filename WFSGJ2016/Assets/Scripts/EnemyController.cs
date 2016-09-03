using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    float minTime = 3f;

    [SerializeField]
    float maxTime = 9f;

    float spawnTime = 0f;
    float time = 0f;

    public GameObject enemy;

    void Start ()
    {
        Debug.Log("Enemy controller started!");
        SetSpawnTime();
        time = minTime;
    }
	
	void Update ()
    {

        time += Time.deltaTime;

        if (time >= spawnTime)
        {

            SpawnEnemy();
            SetSpawnTime();
        }
    }

    void SpawnEnemy()
    {
        time = minTime;
        Instantiate(enemy, RandomPosition(), new Quaternion(0, 0, 0, 0));
    }

    void SetSpawnTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    Vector3 RandomPosition()
    {
        float randResult = Random.value;

        if (randResult > 0.75f)
        {
            return new Vector3(6, 8 * (Random.value - 0.5f), 0);
        }
        else if (randResult > 0.5f)
        {
            return new Vector3(-6, 8 * (Random.value - 0.5f), 0);
        }
        else if (randResult > 0.25f)
        {
            return new Vector3(12 * (Random.value - 0.5f), 4, 0);
        }
        else
        {
            return new Vector3(12 * (Random.value - 0.5f), -4, 0);
        }

    }
}
