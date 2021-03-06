﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;

public class TimerController : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 120; // 2 minutes

    public bool timerStart = false; // bool for the countdown 3,2,1,GÓ
    public Text timerText;
    public AudioSource timerAudio;

    //Endscreen
    public ScoreController scoreNum;
    public Scoreboard scoreBoa;
    public bool endScreenShown;
    public GameObject endScreenGerman;
    public GameObject endScreenEnglish;
    public bool language;
    
    //LaserPointer
    public SteamVR_LaserPointer laserPointer;
    public GameObject player;

    //[HideInInspector] ObjectsToDelete
    public GameObject diffController;
    public GameObject waste;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        timerAudio.Play(0);

        player = GameObject.FindGameObjectWithTag("RightHand");
        laserPointer = player.GetComponent<SteamVR_LaserPointer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(timerStart == true) {

            string minutes = Mathf.Floor(currentTime / 60).ToString();
            string seconds = Mathf.Floor(currentTime % 60).ToString("00");

            timerText.text = minutes + ":" + seconds;

            currentTime -= 1 * Time.deltaTime;

            if (currentTime <= 10)
            {
                timerText.color = Color.red;
            }
            else if (currentTime <= 30)
            {
                timerText.color = Color.yellow;
            }
   
            if (currentTime <= 20)
            {
                timerAudio.UnPause();
            }
            else
            {
                timerAudio.Pause();
            }

            if (currentTime <= 1)
            {
                currentTime = 0;
                timerAudio.Pause();
                if (endScreenShown == false)
                {

                
                    diffController = GameObject.FindWithTag("DiffController");
                    language = diffController.GetComponent<DifficultyController>().language;

                    if (language == true)
                    {
                        endScreenGerman.SetActive(true);
                        scoreBoa.AddHighscoreEntry((int)scoreNum.scoreNumber);
                        endScreenGerman.SetActive(false);
                        endScreenGerman.SetActive(true);
                    }
                    else
                    {
                        endScreenEnglish.SetActive(true);
                        scoreBoa.AddHighscoreEntry((int)scoreNum.scoreNumber);
                        endScreenEnglish.SetActive(false);
                        endScreenEnglish.SetActive(true);
                    }
             
                    //Hide all Waste
                    waste.SetActive(false);
                    //Activate Pointer
                    laserPointer.enabled = !laserPointer.enabled;

                

                    endScreenShown = true;
               

                }
        
               
            }

        }
    }




}
