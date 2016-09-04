using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
    AudioSource clickAudio;
	void Start () {
        clickAudio = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
	
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
        SceneManager.LoadScene("GameModes");
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

    public void Credits()
    {
        StartCoroutine("CCredits");
    }
    IEnumerator CCredits()
    {
        if (clickAudio != null)
            clickAudio.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Credits");
    }

    public void MainMenu()
    {
        StartCoroutine("CMainMenu");
    }
    IEnumerator CMainMenu()
    {
        if (clickAudio != null)
            clickAudio.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
