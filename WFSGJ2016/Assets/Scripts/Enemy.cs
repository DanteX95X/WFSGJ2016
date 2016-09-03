﻿using UnityEngine;
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
        public int houseDamage = 10;

        HealthScript healthScript;

        public GameObject bullet = null;

        public GameObject[] collectibles;

        public float dropProbability;

        bool dead;

        Vector3 diffPosition = new Vector3(0, 0, 0);
        Vector3 destinationPosition = new Vector3(0, 0, 0);

        void Start()
        {
            Debug.Log("Enemy spawned!");

            healthScript = GetComponent<HealthScript>();

            diffPosition = destinationPosition - transform.position;
            diffPosition.Normalize();

            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), diffPosition);
            SetSpawnTime();
            time = 0;
        }

        void Update()
        {
            deltaMove = Time.deltaTime*1;
            if (Mathf.Abs(transform.position.x) > 0.1f || Mathf.Abs(transform.position.y) > 0.1f)
            {
                transform.position += diffPosition * deltaMove;
            }
            else
            {
                Destroy(gameObject);
            }

            time += Time.deltaTime;

            if (time >= spawnTime)
            {

                SpawnBullet();
                SetSpawnTime();
            }

            if (healthScript.health <= 0.0f && !dead)
            {
                dead = true;
                DropCollectible();
                healthScript.Die();
            }
        }

        void SpawnBullet()
        {
            Debug.Log("spawning bullet");
            time = minTime;
            (Instantiate(bullet, transform.position, transform.rotation) as GameObject).GetComponent<Bullet>().ParentCharacter = gameObject;
        }

        void SetSpawnTime()
        {
            spawnTime = Random.Range(minTime, maxTime);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "House")
            {
                collision.collider.gameObject.GetComponentInParent<HealthScript>().TakeDamage(houseDamage);
                Destroy(this.gameObject);
            }
        }

        void DropCollectible()
        {
            if (Random.Range(0.0f, 1.0f) < dropProbability)
            {
                if (collectibles.Length > 0)
                {
                    int randomindex = Random.Range(0, collectibles.Length - 1);
                    Instantiate(collectibles[randomindex], transform.position, transform.rotation);
                }
            }


        }
    }
}