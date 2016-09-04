using UnityEngine;
using System.Collections;

public class PolicemanAnimation : MonoBehaviour {

    Animator animator;
    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>(); 
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(animator.GetBool("walkUp") || animator.GetBool("walkRight"))
        {
            GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
	}
}
