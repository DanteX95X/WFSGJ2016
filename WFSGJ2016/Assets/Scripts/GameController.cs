using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController Instance = null;

	public MeleePlayerController meleePlayer;
	public RangedPlayer rangedPlayer;

	public int ammo;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
