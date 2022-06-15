using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public ScoreDataList scoreDataList;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        scoreDataList = new ScoreDataList();
        if (scoreDataList == null)
        {
            Debug.Log("Start: scoreDataList e null");
            return;
        }
        //Cargar los datos de puntuaciones que tengamos guardados en PlayerPrefs
        LoadData(SceneManager.GetActiveScene().name);
    }

    public void AddScore(ScoreData scoreData)
    {
        if (scoreDataList == null)
        {
            Debug.Log("scoreDataList e null");
            return;
        }

        if (scoreDataList.list == null)
        {
            Debug.Log("scoreDataList.list e null");
            return;
        }


        if (scoreData != null && scoreDataList != null && scoreDataList.list != null)
        {
            scoreDataList.list.Add(scoreData);
            scoreDataList.list.Sort();
            SaveData(SceneManager.GetActiveScene().name);
        }
    }

    private void SaveData(string nombreCircuito)
    {
        //Guardar los datos de puntuaciones en PlayerPrefs
        if (scoreDataList != null)
        {
            PlayerPrefs.SetString("scoreList-" + nombreCircuito, JsonUtility.ToJson(scoreDataList));
        }
    }

    private void LoadData(string nombreCircuito)
    {
        //Cargar los datos de puntuaciones que tengamos guardados en PlayerPrefs
        if (PlayerPrefs.HasKey("scoreList-" + nombreCircuito))
        {
            scoreDataList = JsonUtility.FromJson<ScoreDataList>(PlayerPrefs.GetString("scoreList-" + nombreCircuito));
            scoreDataList.list.Sort();
        }
    }

    public void ClearData(string nombreCircuito)
    {
        if (PlayerPrefs.HasKey("scoreList-" + nombreCircuito))
        {
            PlayerPrefs.DeleteKey("scoreList-" + nombreCircuito);
        }
        scoreDataList.list.Clear();
    }

}
