using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnyKeyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            Destroy(GameObject.Find("GameModeControler"));
            SceneManager.LoadScene("MainMenu");
        }
	
	}
}
