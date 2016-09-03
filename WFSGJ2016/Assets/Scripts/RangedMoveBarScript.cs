using UnityEngine;
using System.Collections;

public class RangedMoveBarScript : MonoBehaviour {
    public Vector3 offset = new Vector3(0,1,0);
    GameObject ranged;
	// Use this for initialization
	void Start () {
        ranged = GameObject.Find("RangedPlayer");
	}
	
	// Update is called once per frame
	void Update () {
        if (ranged != null)
            transform.position = new Vector3(ranged.transform.position.x + offset.x, ranged.transform.position.y + offset.y, ranged.transform.position.z + offset.z);

	}
}
