using UnityEngine;
using System.Collections;

// source: https://unity3d.com/learn/tutorials/projects/tanks-tutorial

public class RangedPlayerMovement : MonoBehaviour
{
    public float speed = 6f;            // The speed that the player will move at.

    //private float h;
    //private float v;
    private Vector3 movement;                   // The vector to store the direction of the player's movement.
    private Rigidbody2D playerRigidbody;


    void Awake ()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

    }
	
	// FixedUpdate is at fixed intervals - used for physics
	void FixedUpdate ()
   {
       //gather input
       //GetInput();
       //RAW - Returns the value of the virtual axis identified by axisName with no smoothing filtering applied.
       float h = Input.GetAxisRaw("Horizontal");
       float v = Input.GetAxisRaw("Vertical");

       //move
       Move(h,v);

       //turn
       //PlayerRotation.Turning();
       // GetComponent<PlayerRotation>().Turning();

       //change animation state if player started to move or stopped
       //Animate();

   }
    
    public void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        // movement.Set(h, 0.0f, v);
        movement.Set(h, v, 0.0f);

        //movement.Normalize();
        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }

}
