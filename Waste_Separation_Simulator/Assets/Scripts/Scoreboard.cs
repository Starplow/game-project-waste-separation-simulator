﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class Scoreboard : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    private void Awake()
    {

        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);
        /*
        highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry{score = 51245},
            new HighscoreEntry{score = 12},
            new HighscoreEntry{score = 13},
            new HighscoreEntry{score = 50},
            new HighscoreEntry{score = 300},
            new HighscoreEntry{score = 700}
        };*/

        //string json = File.ReadAllText(Application.dataPath + "highscorefile.json");

        //Getting the saved highscoreTable json
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        //Debug.Log(json);
        Debug.Log(jsonString + "Playerprefs save");
        //putting it in the list
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        

        // SORTING 
        
        for(int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for(int j=i +1; j<highscores.highscoreEntryList.Count; j++)
            {
                if(highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    //switch if next one is bigger
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;

                }


            }
        }
        


        //creates a line for every score that has been made 
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);

        }

        //putting the scores into a list and saving it to a json 
        /*
        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));
        */
        //File.WriteAllText(Application.dataPath + "highscorefile.json", json);

    }



    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {

            float templateHeight = 20f;
            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);


            int rank = transformList.Count + 1;

            int score = highscoreEntry.score;

            entryTransform.Find("PositionText").GetComponent<Text>().text = rank.ToString();
            entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();

            transformList.Add(entryTransform);
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;

    }


    [System.Serializable]
    private class HighscoreEntry
    {

        public int score;
        


    }


}
