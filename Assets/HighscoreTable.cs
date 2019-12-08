using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour {

    public Transform entryContainer;
    public Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {

        entryTemplate.gameObject.SetActive(false);

        // Add new entry on highscore board
        // AddHighscoreEntry(1000, "CMK");

        // getting saved highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            // There's no stored table, initialize
            Debug.Log("Initializing table with default values...");
            AddHighscoreEntry(1000, "ANNA");
            AddHighscoreEntry(999, "NICO");
            AddHighscoreEntry(0, "O");
            AddHighscoreEntry(0, "O");
            AddHighscoreEntry(0, "O");
            // Reload
            jsonString = PlayerPrefs.GetString("highscoreTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        // Sort entry list by Score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        // create entryTransformList
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        //string jsonString = PlayerPrefs.GetString("highscoreTable");
        //Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //if (highscores == null)
        //{
        //    // There's no stored table, initialize
        //    Debug.Log("Initializing table with default values...");
        //    AddHighscoreEntry(0, "AAA");
        //    AddHighscoreEntry(0, "AAA");
        //    AddHighscoreEntry(0, "AAA");
        //    AddHighscoreEntry(0, "AAA");
        //    AddHighscoreEntry(0, "AAA");
        //    // Reload
        //    jsonString = PlayerPrefs.GetString("highscoreTable");
        //    highscores = JsonUtility.FromJson<Highscores>(jsonString);
        //}

        //// Sort entry list by Score
        //for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        //{
        //    for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
        //    {
        //        if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
        //        {
        //            // Swap
        //            HighscoreEntry tmp = highscores.highscoreEntryList[i];
        //            highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
        //            highscores.highscoreEntryList[j] = tmp;
        //        }
        //    }
        //}

        //highscoreEntryTransformList = new List<Transform>();
        //foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        //{
        //    CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        //}
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;

        // converting the rank
        string rankString;

        switch (rank)
        {
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
            default: rankString = rank + "TH"; break;
        }

        entryTransform.Find("positonText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        //// Set background visible odds and evens, easier to read
        //entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);

        //// Highlight First
        //if (rank == 1)
        //{
        //    entryTransform.Find("posText").GetComponent<Text>().color = Color.green;
        //    entryTransform.Find("scoreText").GetComponent<Text>().color = Color.green;
        //    entryTransform.Find("nameText").GetComponent<Text>().color = Color.green;
        //}

        //// Set tropy
        //switch (rank)
        //{
        //    default:
        //        entryTransform.Find("trophy").gameObject.SetActive(false);
        //        break;
        //    case 1:
        //        entryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("FFD200");
        //        break;
        //    case 2:
        //        entryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("C6C6C6");
        //        break;
        //    case 3:
        //        entryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("B76F56");
        //        break;

        //}

        // Set background visible odds and evens, easier to read
        entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);

        // Highlight First
        if (rank == 1)
        {
            entryTransform.Find("positonText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("scoreText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("nameText").GetComponent<Text>().color = Color.green;
        }

        // Set tropy
        switch (rank)
        {
            default:
                entryTransform.Find("trophy").gameObject.SetActive(false);
                break;
            case 1:
                entryTransform.Find("trophy").GetComponent<Image>().color = new Color32(255, 210, 0, 100);
                break;
            case 2:
                entryTransform.Find("trophy").GetComponent<Image>().color = new Color32(198, 198, 198, 100);
                break;
            case 3:
                entryTransform.Find("trophy").GetComponent<Image>().color = new Color32(183, 111, 86, 100);
                break;

        }

        transformList.Add(entryTransform);

    }

    private void AddHighscoreEntry(int score, string name)
    {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            // There's no stored table, initialize
            highscores = new Highscores()
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    /*
     * Represents a single High score entry
     * */
    [System.Serializable] // for json // PlayerPrefs
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
