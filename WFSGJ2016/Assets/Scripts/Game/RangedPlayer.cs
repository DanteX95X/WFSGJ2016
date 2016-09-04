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
	
    // private Transform muzzle;
    public Transform muzzle;
	public ParticleSystem muzzleFlash;

    bool hasHealingShot = false;

    //int ammunitionRounds = 20;
    public int ammunitionRounds = 20;

    Rigidbody2D rb;
    public Text ammoCounter;
    AudioSource asource;

    public GameObject gun;

	private Camera mainCamera;
	
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ammoCounter.text = ammunitionRounds.ToString();
        asource = GetComponent<AudioSource>();
		
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		
		// muzzle = gameObject.transform.Find("GunMuzzle");
		// muzzle = gameObject.transform.Find("Gun/GunMuzzle");
    }

    void Update ()
    {
	
		Vector3 mouse_world_position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		// Debug.Log(mouse_world_position - transform.position);
		
		// turn player left if mouse moved to the left of character
		if((mouse_world_position.x - transform.position.x) < 0)
		{
			transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
		}
		else
		{
			transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
		}
	
        //if (Input.GetKeyUp(KeyCode.Space))
        // if (Input.GetButtonDown("Player2Attack") && GetComponent<SpriteRenderer>().enabled)
        if (Input.GetButtonDown("Player2Attack"))
        //if (Input.GetButton("Fire1"))
        {
            if (ammunitionRounds > 0)
            {
                if (hasHealingShot)
                {
                    // (Instantiate(healingBullet, transform.position, transform.rotation) as GameObject).GetComponent<HealingBullet>().ParentCharacter = gameObject;
                    (Instantiate(healingBullet, muzzle.position, muzzle.rotation) as GameObject).GetComponent<HealingBullet>().ParentCharacter = gameObject;
                    hasHealingShot = false;
                }
                else
				{
                    // (Instantiate(bullet, gun.transform.position, Quaternion.Euler(0.0f, 0.0f, -90.0f + gun.transform.rotation.eulerAngles.z)) as GameObject).GetComponent<Bullet>().ParentCharacter = gameObject;
                    (Instantiate(bullet, muzzle.position, muzzle.rotation) as GameObject).GetComponent<Bullet>().ParentCharacter = gameObject;
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
