using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
    AudioSource clickAudio;
	void Start () {
        clickAudio = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void StartGame()
    {
        StartCoroutine("CStartGame");
    }
    IEnumerator CStartGame()
    {
        if (clickAudio != null)
            clickAudio.Play();
        yield return new WaitForSeconds(0.5f);
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    public void EndGame()
    {
        StartCoroutine("CEndGame");
    }
    IEnumerator CEndGame()
    {
        if (clickAudio != null)
            clickAudio.Play();
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
}
