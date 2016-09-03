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

//<<<<<<< HEAD
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
            Debug.Log(hasHealingShot);
            if (hasHealingShot)
            {
                (Instantiate(healingBullet, transform.position, transform.rotation) as GameObject).GetComponent<HealingBullet>().ParentCharacter = gameObject;
                hasHealingShot = false;
            }
            else
                (Instantiate(bullet, transform.position, transform.rotation) as GameObject).GetComponent<Bullet>().ParentCharacter = gameObject;
        }

        //if (Input.GetKey(KeyCode.LeftArrow))
//=======
    

//	void Update ()
//    {
        float moveValue = 0.0f;

	    if(Input.GetKey(KeyCode.LeftArrow))
//>>>>>>> d03d221d04d055bcd3b41f8ed85f515fc3a1666a
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
//<<<<<<< HEAD
//=======

        rb.velocity = transform.up * moveValue * Time.deltaTime;

/*        if(Input.GetKeyUp(KeyCode.Space))
        {
            (Instantiate(bullet, transform.position, transform.rotation) as GameObject).GetComponent<Bullet>().ParentCharacter = gameObject;
        }
>>>>>>> d03d221d04d055bcd3b41f8ed85f515fc3a1666a*/
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
