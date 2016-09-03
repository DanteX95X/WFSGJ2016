using UnityEngine;
using System.Collections;

public class HealthCollectible : Collectible {

	int healthValue = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Collect()
	{
		GameController.Instance.rangedPlayer.GetComponent<HealthScript>().AddHealth(healthValue);
		base.Collect();
	}
}
