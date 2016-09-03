using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class AmmoCheckPoint : MonoBehaviour {
    public Text ammoCounter;

    [SerializeField]
    GameObject ammoPickUp = null;

    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    { 
        if(collider.gameObject.name == "MeleePlayer")
        {
            MeleePlayerController meleeController = collider.gameObject.GetComponent<MeleePlayerController>();
            /*FindObjectOfType<RangedPlayer>().ReplenishAmmo(meleeController.temporaryAmmo);
            ammoCounter.text  = (Int32.Parse(ammoCounter.text) + meleeController.temporaryAmmo).ToString();
            meleeController.temporaryAmmo = 0;*/
            if (meleeController.temporaryAmmo > 0)
            {
                GameObject thrownAmmo = Instantiate(ammoPickUp, transform.position, Quaternion.identity) as GameObject;
                collider.gameObject.GetComponent<MeleePlayerController>().child = thrownAmmo.GetComponent<AmmoCollectible>();
                thrownAmmo.GetComponent<CircleCollider2D>().isTrigger = false;
                thrownAmmo.GetComponent<Rigidbody2D>().AddForce((transform.position - collider.gameObject.transform.position) * 3);
                StartCoroutine(RestoreTrigger(thrownAmmo, collider.gameObject));
                meleeController.temporaryAmmo = 0;
            }
        }
    }

    IEnumerator RestoreTrigger(GameObject thrownAmmo, GameObject thrower)
    {
        while((thrownAmmo.transform.position - thrower.transform.position).magnitude < 1)
            yield return null;
        thrownAmmo.GetComponent<Rigidbody2D>().drag = 100000;
        thrownAmmo.GetComponent<CircleCollider2D>().isTrigger = true;
        thrower.GetComponent<MeleePlayerController>().child = null;
    }
}
