using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 15;
    public int damage = 1;

    public GameObject ParentCharacter { get; set; }

    float counter = 0;

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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject != ParentCharacter && (collider.gameObject.tag == "Player" || collider.gameObject.tag == "Enemy"))
        {
            //collider.gameObject.GetComponent<IMortal>().Die();
            collider.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
            Debug.Log("Character has been shot");
        }

        if (collider.gameObject != ParentCharacter)
            Destroy(gameObject);
    }
}
