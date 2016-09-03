using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class AmmoCollectible : Collectible
{

	public int ammoReplenishment = 15;

    //public Text guiCounter = null;

    public Text ammoCounter;

	void Start ()
    {
        ammoCounter = GameObject.Find("ammoText").GetComponent<Text>();
	}
	
	void Update ()
    {
	
	}

	public override void Collect()
	{
        Debug.Log("Collected");
        //GameController.Instance.ammo += ammoReplenishment;
        GameObject.FindObjectOfType<MeleePlayerController>().AddTemporaryAmmo(ammoReplenishment);
       // ammoCounter.text = (Int32.Parse(ammoCounter.text) + ammoReplenishment).ToString();



		base.Collect();
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "RangedPlayer")
        {
            Debug.Log("Picked Up");
            collider.gameObject.GetComponent<RangedPlayer>().ReplenishAmmo(ammoReplenishment);
            ammoCounter.text = (Int32.Parse(ammoCounter.text) + ammoReplenishment).ToString();
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "RangedPlayer")
        {
            Debug.Log("Picked Up");
            collider.gameObject.GetComponent<RangedPlayer>().ReplenishAmmo(ammoReplenishment);
            ammoCounter.text = (Int32.Parse(ammoCounter.text) + ammoReplenishment).ToString();
            Destroy(gameObject);
        }
    }
}
