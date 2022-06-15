using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public ScoreDataList scoreDataList = new ScoreDataList();

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //Cargar los datos de puntuaciones que tengamos guardados en PlayerPrefs
        LoadData();
    }

    public void AddScore(ScoreData scoreData)
    {
        scoreDataList.list.Add(scoreData);

        SaveData();
    }

    private void SaveData()
    {
        //Guardar los datos de puntuaciones en PlayerPrefs
        if (scoreDataList != null)
        {
            PlayerPrefs.SetString("scoreList", JsonUtility.ToJson(scoreDataList));
        }
    }

    private void LoadData()
    {
        //Cargar los datos de puntuaciones que tengamos guardados en PlayerPrefs
        if (PlayerPrefs.HasKey("scoreList"))
        {
            scoreDataList = JsonUtility.FromJson<ScoreDataList>(PlayerPrefs.GetString("scoreList"));
        }
    }

    public void ClearData()
    {
        if (PlayerPrefs.HasKey("scoreList"))
        {
            PlayerPrefs.DeleteKey("scoreList");
        }
        scoreDataList.list.Clear();
    }

}
