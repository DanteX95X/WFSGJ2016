using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("Game");
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
