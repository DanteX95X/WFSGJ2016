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

    Rigidbody2D rb;
	
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	void Update ()
    {
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

        if(Input.GetKeyUp(KeyCode.Space))
        {
            (Instantiate(bullet, transform.position, transform.rotation) as GameObject).GetComponent<Bullet>().ParentCharacter = gameObject;
        }
	}

    public void Die()
    {
        //TODO: Make it die
    }
}
