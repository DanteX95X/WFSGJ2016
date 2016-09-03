using UnityEngine;
using System.Collections;

public class HealingBullet : Bullet
{
    [SerializeField]
    int healingValue = 5;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "MeleePlayer")
        {
            collider.gameObject.GetComponent<HealthScript>().TakeDamage(-healingValue);
            Debug.Log("Companion has been healed");
        }

        if (collider.gameObject != ParentCharacter && collider.gameObject.tag != "AmmoCheckPoint")
            Destroy(gameObject);
    }
}
