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
	private ParticleSystem muzzleFlash;

    bool hasHealingShot = false;

    int ammunitionRounds = 20;

    Rigidbody2D rb;
    public Text ammoCounter;
    AudioSource asource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ammoCounter.text = ammunitionRounds.ToString();
        asource = GetComponent<AudioSource>();
		
		muzzle = gameObject.transform.Find("GunMuzzle");
		muzzleFlash = muzzle.GetComponent<ParticleSystem>();
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
                    (Instantiate(bullet, transform.position, transform.rotation) as GameObject).GetComponent<Bullet>().ParentCharacter = gameObject;
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
            transform.Rotate(0, 0, Input.GetAxis("Player2Rotate") * rotationSpeed * Time.deltaTime);
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
