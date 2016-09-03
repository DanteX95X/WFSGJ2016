using UnityEngine;
using System.Collections;

public class RangedPlayer : MonoBehaviour, IMortal
{
    [SerializeField]
    float rotationSpeed = 100;

    [SerializeField]
    float movementSpeed = 10;

    [SerializeField]
    GameObject bullet = null;

    [SerializeField]
    GameObject healingBullet = null;

    bool hasHealingShot = false;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (hasHealingShot)
            {
                (Instantiate(healingBullet, transform.position, transform.rotation) as GameObject).GetComponent<HealingBullet>().ParentCharacter = gameObject;
                hasHealingShot = false;
            }
            else
                (Instantiate(bullet, transform.position, transform.rotation) as GameObject).GetComponent<Bullet>().ParentCharacter = gameObject;
        }
        float moveValue = 0.0f;

	    if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            moveValue = movementSpeed;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            moveValue = -movementSpeed;
        }
        rb.velocity = transform.up * moveValue * Time.deltaTime;
	}

    public void Die()
    {
        //TODO: Make it die
    }

    public void PickUpHealthCollectible()
    {
        hasHealingShot = true;
    }
}
