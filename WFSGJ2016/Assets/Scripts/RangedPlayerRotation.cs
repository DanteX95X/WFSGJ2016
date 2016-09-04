using UnityEngine;
using System.Collections;

// source: https://unity3d.com/learn/tutorials/projects/tanks-tutorial

public class RangedPlayerRotation : MonoBehaviour
{
    
    // private int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    // private float camRayLength = 100f;          // The length of the ray from the camera into the scene.

    // private Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    private Rigidbody2D playerRigidbody;          // Reference to the player's rigidbody.

	private Camera mainCamera;
	
	// public int damping;	//var damping:int=2;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
	
	void Start()
	{
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();;
	}
	
	void Update()
	{
		Vector3 mouse_world_position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), mouse_world_position - transform.position);	
	}
    
}
