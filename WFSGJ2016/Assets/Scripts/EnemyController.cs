using UnityEngine;
using System.Collections;
using Assets.Scripts.Enemy;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    float minTime = 3f;

    [SerializeField]
    float maxTime = 9f;

    float spawnTime = 0f;
    float time = 0f;

    public GameObject[] houses = null;

    public GameObject enemy;	//prefab
	
	private GameObject enemy_obj;
	private CameraControllerTwoPlayers camera_controller;

    void Start()
    {
        Debug.Log("Enemy controller started!");

        houses = GameObject.FindGameObjectsWithTag("House");

        SetSpawnTime();
        time = minTime;
		
		camera_controller = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<CameraControllerTwoPlayers>();
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
        // (Instantiate(enemy, RandomPosition(), new Quaternion(0, 0, 0, 0)) as GameObject).GetComponent<Enemy>().SetDestination(RandomDestination());
		// instantiate
		enemy_obj = (GameObject)Instantiate(enemy, RandomPosition(), new Quaternion(0, 0, 0, 0));
		// enemy_obj = Instantiate(enemy, RandomPosition(), new Quaternion(0, 0, 0, 0)) as GameObject);
		// initialize
		enemy_obj.GetComponent<Enemy>().SetDestination(RandomDestination());
		camera_controller.AddTarget(enemy_obj.transform);
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

    Vector3 RandomDestination()
    {
        if (houses != null)
        {
            return houses[Random.Range(0, houses.Length - 1)].transform.position;
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }
        
}
