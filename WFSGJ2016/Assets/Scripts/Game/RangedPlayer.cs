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

        if (Input.GetKey(KeyCode.LeftArrow))
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
