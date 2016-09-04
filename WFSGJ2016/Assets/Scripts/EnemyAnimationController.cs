using UnityEngine;
using System.Collections;

public class EnemyAnimationController : MonoBehaviour {

	public Animator animator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = transform.up.normalized;

		if (dir.y > 0.7f) 
		{
			animator.SetBool("walkUp", true);

            animator.SetBool("walkDown", false);
            animator.SetBool("walkRight", false);
            animator.SetBool("walkLeft", false);
		}
		if (dir.y < -0.7f) 
		{
			animator.SetBool("walkDown", true);

            animator.SetBool("walkUp", false);
            animator.SetBool("walkRight", false);
            animator.SetBool("walkLeft", false);
		}
			
		if (dir.x > 0.7f) 
		{
            animator.SetBool("walkRight", true);

            animator.SetBool("walkUp", false);
            animator.SetBool("walkDown", false);
            animator.SetBool("walkLeft", false);
		}

        if (dir.x < -0.7f)
        {
            animator.SetBool("walkLeft", true);

            animator.SetBool("walkUp", false);
            animator.SetBool("walkDown", false);
            animator.SetBool("walkRight", false);
        }
	}
}
