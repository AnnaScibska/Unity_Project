using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

    //private Transform entryContainer;
    //private Transform entryTemplate;
    //// private List<Transform> highscoreEntryTransformList;

    //private void Awake()
    //{
    //    entryContainer = transform.Find("highscoreEntryContainer");
    //    entryTemplate = entryContainer.Find("highscoreEntryTemplate");

    //    entryTemplate.gameObject.SetActive(false);

    //    float templateHeight = 30f;
    //    for (int i = 0; i < 10; i++)
    //    {
    //        Transform entryTransform = Instantiate(entryTemplate, entryContainer);
    //        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
    //        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
    //        entryTransform.gameObject.SetActive(true);

    //        int rank = i + 1;

    //        // converting the rank
    //        string rankString;

    //        switch (rank)
    //        {
    //            case 1: rankString = "1ST"; break;
    //            case 2: rankString = "2ND"; break;
    //            case 3: rankString = "1RD"; break;
    //            default: rankString = rank + "TH"; break;
    //        }

    //        entryTransform.Find("PositonText").GetComponent<Text>().text = rankString;

    //        int score = Random.Range(0, 10000);
    //        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();

    //        string name = "AAA";
    //        entryTransform.Find("NameText").GetComponent<Text>().text = name;
    //    }

    //    //string jsonString = PlayerPrefs.GetString("highscoreTable");
    //    //Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

    //    //if (highscores == null)
    //    //{
    //    //    // There's no stored table, initialize
    //    //    Debug.Log("Initializing table with default values...");
    //    //    AddHighscoreEntry(0, "AAA");
    //    //    AddHighscoreEntry(0, "AAA");
    //    //    AddHighscoreEntry(0, "AAA");
    //    //    AddHighscoreEntry(0, "AAA");
    //    //    AddHighscoreEntry(0, "AAA");
    //    //    // Reload
    //    //    jsonString = PlayerPrefs.GetString("highscoreTable");
    //    //    highscores = JsonUtility.FromJson<Highscores>(jsonString);
    //    //}

    //    //// Sort entry list by Score
    //    //for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
    //    //{
    //    //    for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
    //    //    {
    //    //        if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
    //    //        {
    //    //            // Swap
    //    //            HighscoreEntry tmp = highscores.highscoreEntryList[i];
    //    //            highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
    //    //            highscores.highscoreEntryList[j] = tmp;
    //    //        }
    //    //    }
    //    //}

    //    //highscoreEntryTransformList = new List<Transform>();
    //    //foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
    //    //{
    //    //    CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
    //    //}
    //}
}
