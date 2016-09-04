using UnityEngine;
using System.Collections;

public class AudioStayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioStayScript[] au = GameObject.FindObjectsOfType<AudioStayScript>();
        if (au.Length>1)
        {
            for (int i = 1; i < au.Length;i++ )
                Destroy(au[i].gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
