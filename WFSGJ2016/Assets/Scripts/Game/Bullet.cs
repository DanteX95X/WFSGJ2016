using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 15;

    public GameObject ParentCharacter { get; set; }

    float counter = 0;
    void Start()
    {
        Debug.Log("Ranged player spawned");
    }

	void Update ()
    {
        transform.position += transform.up * movementSpeed * Time.deltaTime;
        DestroyBullet();
	}

    void DestroyBullet()
    {
        counter += Time.deltaTime;
        if (counter > 2)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != ParentCharacter && (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy"))
        {
            collision.gameObject.GetComponent<IMortal>().Die();
            Debug.Log("Character has been shot");
            Destroy(gameObject);
        }
    }
}
