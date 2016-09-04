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
	
    private Transform muzzle;
	public ParticleSystem muzzleFlash;

    bool hasHealingShot = false;

    //int ammunitionRounds = 20;
    public int ammunitionRounds = 20;

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
        //if (Input.GetKeyUp(KeyCode.Space))
        if (Input.GetButtonDown("Player2Attack"))
        //if (Input.GetButton("Fire1"))
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
		
    }
	
	/*
	private void FixedUpdate()
	{
		// Rotate();
		// float moveValue = Move();

        // rb.velocity = transform.up * moveValue * Time.deltaTime;
	}
	
	private void Rotate()
	{
	    if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
	}
	private float Move()
	{
        float moveValue = 0.0f;
		
		if(Input.GetKey(KeyCode.UpArrow))
        {
            moveValue = movementSpeed;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            moveValue = -movementSpeed;
        }

		
		return moveValue;
	}
	*/

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
