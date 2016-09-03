using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class AmmoCheckPoint : MonoBehaviour {
    public Text ammoCounter;
   // int ammoReplenishment = 15;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    { 
        if(collider.gameObject.name == "MeleePlayer")
        {
            MeleePlayerController meleeController = collider.gameObject.GetComponent<MeleePlayerController>();
            FindObjectOfType<RangedPlayer>().ReplenishAmmo(meleeController.temporaryAmmo);
            ammoCounter.text  = (Int32.Parse(ammoCounter.text) + meleeController.temporaryAmmo).ToString();
            meleeController.temporaryAmmo = 0;
        }
    }
}
