using UnityEngine;
using System.Collections;

public class AmmoCollectible : Collectible {

	int ammoCount = 15;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Collect()
	{
		GameController.Instance.ammo += ammoCount;
		base.Collect();
	}
}
