using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

    public int damage = 20;
    AudioSource asource;


	// Use this for initialization
	void Start () {
        asource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            collider.GetComponent<HealthScript>().TakeDamage(damage);
            asource.PlayOneShot(asource.clip);
        }
    }
}
