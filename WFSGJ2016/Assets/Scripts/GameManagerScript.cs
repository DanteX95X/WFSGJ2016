using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {
    public Canvas pauseMenu;
    Button ret;
	// Use this for initialization
	void Start () {
        pauseMenu.enabled = false;
        ret = GameObject.Find("Return").GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Cancel")){
            if (Time.timeScale == 1)
            {
                
                Time.timeScale = 0;
                pauseMenu.enabled = true;
                ret.Select();
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.enabled = false;
            }
            }
	}
    public void Return()
    {
        Time.timeScale = 1;
        pauseMenu.enabled = false;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

}
