using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        float deltaMove = 0f;
        float minTime = 1f;
        float maxTime = 3f;
        float spawnTime = 0f;
        float time = 0f;

        public GameObject bullet;

        Vector3 diffPosition = new Vector3(0, 0, 0);
        Vector3 destinationPosition = new Vector3(0, 0, 0);

        void Start()
        {
            Debug.Log("enemy spawned");

            diffPosition = destinationPosition - transform.position;
            diffPosition.Normalize();

            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), diffPosition);
            SetSpawnTime();
            time = 0;
        }

        void Update()
        {
            deltaMove = Time.deltaTime*1;
            if (Mathf.Abs(transform.position.x) > 0.1f && Mathf.Abs(transform.position.y) > 0.1f)
            {
                transform.position += diffPosition * deltaMove;
            }

            time += Time.deltaTime;

            if (time >= spawnTime)
            {

                SpawnBullet();
                SetSpawnTime();
            }
        }

        void SpawnBullet()
        {
            time = minTime;
            Instantiate(bullet, transform.position, transform.rotation);
        }

        void SetSpawnTime()
        {
            spawnTime = Random.Range(minTime, maxTime);
        }
    }
}