using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class AmmoCollectible : Collectible
{

	int ammoReplenishment = 15;

    //public Text guiCounter = null;

    Text ammoCounter;

	void Start ()
    {
        ammoCounter = GameObject.Find("ammoText").GetComponent<Text>();
	}
	
	void Update ()
    {
	
	}

	public override void Collect()
	{
        //GameController.Instance.ammo += ammoReplenishment;
        GameObject.FindObjectOfType<RangedPlayer>().ReplenishAmmo(ammoReplenishment);
        ammoCounter.text = (Int32.Parse(ammoCounter.text) + ammoReplenishment).ToString();
		base.Collect();
	}
}
