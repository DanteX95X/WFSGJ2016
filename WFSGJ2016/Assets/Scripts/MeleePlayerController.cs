﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MeleePlayerController : MonoBehaviour {

    public float movementSpeed = 100.0f;
    public GameObject attackColliderGO;

    public int temporaryAmmo;

    CircleCollider2D attackCollider;
    Faceing faceing;
	Rigidbody2D rb;
	Animator animator;
    Text ammoText;

    float attackDelay = 0.5f;

    public AmmoCollectible child = null;

    enum Faceing
    {
        Up,
        Right,
        Down,
        Left
    }

	// Use this for initialization
	void Start () {
        attackCollider = attackColliderGO.GetComponent<CircleCollider2D>();
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
        temporaryAmmo = 0;
        ammoText = GetComponentsInChildren<Text>()[1];
        ammoText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        // Move();
        Attack();
	}
	
	void FixedUpdate () {
        Move();
	}

	void Move()
	{
        float newXpos = 0.0f;
        float newYpos = 0.0f;

		if (Input.GetAxis("Player1Horizontal") != 0.0f) 
		{
            newXpos = Input.GetAxis("Player1Horizontal") * movementSpeed * Time.deltaTime;
            if (Input.GetAxis("Player1Horizontal") < 0.0f)
                faceing = Faceing.Left;
            else if (Input.GetAxis("Player1Horizontal") > 0.0f)
                faceing = Faceing.Right;
		}

        if (Input.GetAxis("Player1Vertical") != 0.0f)
        {
            newYpos = Input.GetAxis("Player1Vertical") * movementSpeed * Time.deltaTime;
            if (Input.GetAxis("Player1Vertical") < 0.0f)
                faceing = Faceing.Down;
            else if (Input.GetAxis("Player1Vertical") > 0.0f)
                faceing = Faceing.Up;
        }

//		if (newYpos < 0.0f)
//			animator.SetBool("walkDown", true);
//		else if (newYpos > 0.0f)
//			animator.SetBool("walkUp", true);
//		else 
//		{
//			animator.SetBool("walkDown", false);
//			animator.SetBool("walkUp", false);
//		}
//
//		if (newXpos < 0.0f)
//			animator.SetBool("walkLeft", true);
//		else if (newXpos > 0.0f)
//			animator.SetBool("walkRight", true);
//		else 
//		{
//			animator.SetBool("walkRight", false);
//			animator.SetBool("walkLeft", false);
//		}

		if (faceing == Faceing.Up && newYpos > 0.0f) {
			animator.SetBool("walkUp", true);
			animator.SetBool("walkDown", false);
			animator.SetBool("walkRight", false);
			animator.SetBool("walkLeft", false);
		} else if (faceing == Faceing.Down && newYpos < 0.0f) {
			animator.SetBool("walkDown", true);
			animator.SetBool("walkUp", false);
			animator.SetBool("walkRight", false);
			animator.SetBool("walkLeft", false);
		} else if (faceing == Faceing.Left && newXpos < 0.0f) {
			animator.SetBool("walkLeft", true);
			animator.SetBool("walkDown", false);
			animator.SetBool("walkUp", false);
			animator.SetBool("walkRight", false);
		} else if (faceing == Faceing.Right && newXpos > 0.0f) {
			animator.SetBool("walkRight", true);
			animator.SetBool("walkDown", false);
			animator.SetBool("walkUp", false);
			animator.SetBool("walkLeft", false);
		}	
		else 
		{
			animator.SetBool("walkDown", false);
			animator.SetBool("walkUp", false);
			animator.SetBool("walkRight", false);
			animator.SetBool("walkLeft", false);
		}
			
		rb.velocity = new Vector2(newXpos, newYpos);
	}

    void Attack()
    {
        if (Input.GetButton("Player1Attack") && !GetComponent<CPRScipt>().inAgony )
        {
            if (faceing == Faceing.Up)
                attackCollider.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            else if (faceing == Faceing.Down)
                attackCollider.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            else if (faceing == Faceing.Left)
                attackCollider.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
            else if (faceing == Faceing.Right)
                attackCollider.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);

            StartCoroutine("EnableAttackCollider");
        }
    }

    IEnumerator EnableAttackCollider()
    {
        attackCollider.enabled = true;
        yield return new WaitForSeconds(attackDelay);
        attackCollider.enabled = false;
    }

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Collectible" && child == null) 
		{
			collider.gameObject.GetComponent<Collectible>().Collect();
		}
	}

	/*void  OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Collectible") 
		{
			collision.gameObject.GetComponent<Collectible>().Collect();
		}
	}*/

    public void AddTemporaryAmmo(int value)
    {
        temporaryAmmo += value;
        SetGUIAmmo();
    }
    public void SetGUIAmmo()
    {
        if (temporaryAmmo != 0)
            ammoText.text = temporaryAmmo.ToString();
        else
            ammoText.text = "";
    }
}
