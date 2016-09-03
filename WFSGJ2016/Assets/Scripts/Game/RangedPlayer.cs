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
	
	void Update ()
    {
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
            transform.position += transform.up * movementSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += -transform.up * movementSpeed * Time.deltaTime;
        }

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
