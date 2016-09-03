using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {
    public Canvas pauseMenu;
    public Canvas gameOver;

    GameObject house;
    GameObject melee;
    GameObject ranged;
    Button ret;
	// Use this for initialization
	void Start () {
        pauseMenu.enabled = false;
        gameOver.enabled = false;
        ret = GameObject.Find("Return").GetComponent<Button>();
        house = GameObject.Find("House");
        melee = GameObject.Find("MeleePlayer");
        ranged = GameObject.Find("RangedPlayer");
	}
	
	// Update is called once per frame
	void Update () {
        if (pauseMenu != null)
        {
            checkOver();
            checkMenu();
        }

	}

    void checkOver()
    {
        if (house == null || melee == null || ranged == null)
        {
            Time.timeScale = 0;
            gameOver.enabled = true;
            pauseMenu.enabled = false;
            pauseMenu = null;
            gameOver.GetComponentInChildren<Button>().Select();
            GetComponent<AudioSource>().Play();

        }

    }
    void checkMenu()
    {
        if (Input.GetButtonDown("Cancel"))
        {
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
