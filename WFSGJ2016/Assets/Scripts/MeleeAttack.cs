using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

    public int damage = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            collider.GetComponent<HealthScript>().TakeDamage(damage);
        }
    }
}
