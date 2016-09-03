using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 15;

    public GameObject ParentCharacter { get; set; }

    float counter = 0;

	protected void Update ()
    {
        transform.position += transform.up * movementSpeed * Time.deltaTime;
        DestroyBullet();
	}

    protected void DestroyBullet()
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
            Debug.Log("Character has been shot");
        }

        if (collider.gameObject != ParentCharacter)
            Destroy(gameObject);
    }
}
