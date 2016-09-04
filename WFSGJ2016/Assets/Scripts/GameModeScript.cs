using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class GameModeScript : MonoBehaviour {
    public int modeNum;
    GameObject old;
    Action function;
    Text[] texts;
    public int intCounter;
    public float floatCounter;
    public int minutesReq = 5;
    public int enemiesReq = 50;
    public int ammoReq = 100;
    GameObject pan;
    bool won;
    MeleePlayerController melee;
    RangedPlayer ranged ;
	// Use this for initialization
    AudioSource clickAudio;
    void Start()
    {
        clickAudio = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
        old = GameObject.Find("MenuManager");
        intCounter = 0;
        floatCounter = 0;
        function = Nothing;
        pan = GameObject.Find("Panel");
        pan.SetActive(false);
        won = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (melee == null || ranged == null)
        {
            melee = GameObject.FindObjectOfType<MeleePlayerController>();
            ranged = GameObject.FindObjectOfType<RangedPlayer>();
        }
        if(!won)
            function();
	}
    public void Survival()
    {
        modeNum = 0;
        Destroy(old);
        StartGame();
    }
    public void Copkiller()
    {
        modeNum = 1;
        Destroy(old);
        StartGame();
    }
    public void Gather()
    {
        modeNum = 2;
        Destroy(old);
        StartGame();
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

        switch(modeNum){
            case 0:
                function = SurvivalWin;
                texts = GetComponentsInChildren<Text>();
                texts[0].text = "REMAINING TIME:";

                break;
            case 1:
                function = CopkillerWin;
                texts = GetComponentsInChildren<Text>();
                texts[0].text = "COPS NEUTRALIZED:";
                break;
            case 2:
                function = GatherWin;
                texts = GetComponentsInChildren<Text>();
                texts[0].text = "AMMO GATHERED:";
                break;
        }
    }

    void SurvivalWin()
    {
        floatCounter += Time.deltaTime;
        texts[1].text = Math.Round((floatCounter/60),3).ToString() + " / "+minutesReq.ToString();
        if (floatCounter >= 300)
        {
            won = true;
            pan.SetActive(true);
            pan.GetComponentsInChildren<Text>()[1].text = texts[0].text+"\n" + texts[1].text;
            SceneManager.LoadScene("End");
            texts[0].text = "";
            texts[1].text = "";
            
            
        }
            
        
    }
    void CopkillerWin()
    {
        texts[1].text = intCounter.ToString() + " / "+enemiesReq.ToString();
        if (intCounter >= enemiesReq)
        {
            won = true;
            pan.SetActive(true);
            pan.GetComponentsInChildren<Text>()[1].text = texts[0].text + "\n" + texts[1].text;
            SceneManager.LoadScene("End");
            texts[0].text = "";
            texts[1].text = "";


        }
    }
    void GatherWin()
    {

        intCounter = melee.temporaryAmmo + ranged.ammunitionRounds;
        texts[1].text = intCounter.ToString() + " / "+ammoReq.ToString();
        if (intCounter >= ammoReq)
        {
            won = true;
            pan.SetActive(true);
            pan.GetComponentsInChildren<Text>()[1].text = texts[0].text + "\n" + texts[1].text;
            SceneManager.LoadScene("End");
            texts[0].text = "";
            texts[1].text = "";


        }


    }
    void Nothing() { }



}
