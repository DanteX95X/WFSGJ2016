using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

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
	
    // public GameObject muzzleFlash;
    // public GameObject muzzle;
    private Transform muzzle;
	public ParticleSystem muzzleFlash;

    bool hasHealingShot = false;

    int ammunitionRounds = 20;

    Rigidbody2D rb;
    public Text ammoCounter;
    AudioSource asource;

    public GameObject gun;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ammoCounter.text = ammunitionRounds.ToString();
        asource = GetComponent<AudioSource>();
		
		muzzle = gameObject.transform.Find("GunMuzzle");
    }

    void Update ()
    {
        if (Input.GetButtonUp("Player2Attack"))
        {
            if (ammunitionRounds > 0)
            {
                if (hasHealingShot)
                {
                    (Instantiate(healingBullet, transform.position, transform.rotation) as GameObject).GetComponent<HealingBullet>().ParentCharacter = gameObject;
                    hasHealingShot = false;
                }
                else
				{
                    (Instantiate(bullet, gun.transform.position, Quaternion.Euler(0.0f, 0.0f, -90.0f + gun.transform.rotation.eulerAngles.z)) as GameObject).GetComponent<Bullet>().ParentCharacter = gameObject;
					// muzzle flash
                    // Instantiate(muzzleFlash, muzzle.position, muzzle.rotation);
					muzzleFlash.Play();
					muzzleFlash.Emit(25);	//count
				}
                --ammunitionRounds;
                ammoCounter.text = (Int32.Parse(ammoCounter.text) - 1).ToString();
                asource.PlayOneShot(asource.clip);
            }
        }
        float moveValue = 0.0f;

	    /*if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }*/
        if(Input.GetButton("Player2Rotate"))
        {
            gun.transform.Rotate(0, 0, Input.GetAxis("Player2Rotate") * rotationSpeed * Time.deltaTime);
            Debug.Log(gun.transform.rotation.eulerAngles);

            Debug.Log(gun.transform.right);

            if (!GetComponent<SpriteRenderer>().flipX)
            {
                if (gun.transform.right.x < 0.0f)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                    gun.GetComponent<SpriteRenderer>().flipY = true;
                }
            }
            else
            {
                if (gun.transform.right.x > 0.0f)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                    gun.GetComponent<SpriteRenderer>().flipY = false;
                }
            }

        }
        if(Input.GetButton("Player2Move"))
        {
            moveValue = Input.GetAxis("Player2Move") * movementSpeed;
        }


        /*if(Input.GetKey(KeyCode.UpArrow))
        {
            moveValue = movementSpeed;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            moveValue = -movementSpeed;
        }*/
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

    public void ReplenishAmmo(int ammoReplenishment)
    {
        ammunitionRounds += ammoReplenishment;
    }
}
