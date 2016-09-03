using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Assets.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        float deltaMove = 0f;

        //[SerializeField]
        float speed = 100;

        [SerializeField]
        float minTime = 1f;

        [SerializeField]
        float maxTime = 3f;

        bool isMoving;

        float spawnTime = 0f;
        float time = 0f;
        public int houseDamage = 10;

        HealthScript healthScript;

        public GameObject bullet = null;

        public GameObject[] collectibles;

        public float dropProbability;

        bool dead;

        Vector3 diffPosition = new Vector3(0, 0, 0);

       // [SerializeField]
        Vector3 destinationPosition = new Vector3(0, 0, 0);

        MeleePlayerController meleePlayer;
        AudioSource asource;
		
		public CameraControllerTwoPlayers camera_controller; 

        void Start()
        {
            asource = GetComponent<AudioSource>();
            Debug.Log("Enemy spawned!");

            healthScript = GetComponent<HealthScript>();

            diffPosition = destinationPosition - transform.position;
            diffPosition.Normalize();

            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), diffPosition);
            SetSpawnTime();
            time = 0;

            isMoving = true;

            meleePlayer = FindObjectOfType<MeleePlayerController>();
        }

        void Update()
        {
            deltaMove = Time.deltaTime*1;
            if (Mathf.Abs(transform.position.x) > 0.1f || Mathf.Abs(transform.position.y) > 0.1f)
            {
                if (isMoving == true) transform.position += diffPosition * deltaMove;
            }
            else
            {
                Destroy(gameObject);
            }

            time += Time.deltaTime;

            if (time >= spawnTime)
            {

                if (meleePlayer != null && (Quaternion.LookRotation(new Vector3(0, 0, 1), meleePlayer.transform.position - transform.position).eulerAngles - transform.rotation.eulerAngles).magnitude > 5)
                {
                    isMoving = false;
                    Debug.Log("Rotation");
                    Rotate(Quaternion.LookRotation(new Vector3(0, 0, 1), meleePlayer.transform.position - transform.position));
                }
                else
                {
                    SpawnBullet();
                    SetSpawnTime();
                   // transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), diffPosition);
                    isMoving = true;
                }
            }
            else
            {
                Rotate(Quaternion.LookRotation(new Vector3(0, 0, 1), diffPosition));
            }


            if (healthScript.health <= 0.0f && !dead)
            {
                dead = true;
                DropCollectible();
                healthScript.Die();
            }
        }

        void Rotate(Quaternion to)
        {
            float step = speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, to , step);
        }

        void SpawnBullet()
        {
            Debug.Log("spawning bullet");
            time = minTime;
            if (transform != null && meleePlayer != null)
            {
                (Instantiate(bullet, transform.position, Quaternion.LookRotation(new Vector3(0, 0, 1), meleePlayer.transform.position - transform.position)) as GameObject).GetComponent<Bullet>().ParentCharacter = gameObject;
                asource.PlayOneShot(asource.clip);
            }
        }

        public void SetDestination(Vector3 destination)
        {
            destinationPosition = destination;
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
				camera_controller.RemoveTarget(transform);
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