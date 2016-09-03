using UnityEngine;
using System.Collections;

public class HealthCollectible : Collectible
{
	public override void Collect()
	{
        FindObjectOfType<RangedPlayer>().PickUpHealthCollectible();
		base.Collect();
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "RangedPlayer")
            Collect();
    }
}
