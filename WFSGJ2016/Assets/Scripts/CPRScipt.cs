using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CPRScipt : MonoBehaviour {
    Text resCounter;
    HealthScript hp;
    MeleePlayerController pContr;
    int count;
    public bool inAgony;

	// Use this for initialization
	void Start () {
	    resCounter = GetComponentInChildren<Text>();
        hp = GetComponent<HealthScript>();
        pContr = GetComponent<MeleePlayerController>();
        count = 10;
        inAgony = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (hp.health <= 0 && !inAgony)
        {
            hp.health = 0;
            inAgony = true;
            resCounter.text = count.ToString();
            pContr.movementSpeed /= 2;
            InvokeRepeating("Agony",1,1);
        }
        else if (hp.health > 0 && inAgony)
        {
            inAgony = false;
            count = 10;
            resCounter.text = "";
            pContr.movementSpeed *= 2;
            CancelInvoke("Agony");

        }


	}
    void Agony()
    {
        if (count > 0)
        {
            count -= 1;
            resCounter.text = count.ToString();
        }
        else
            hp.Die();


    }
}
