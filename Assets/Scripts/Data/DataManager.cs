using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        LoadData(SceneManager.GetActiveScene().name);
    }

    public void AddScore(ScoreData scoreData)
    {
        scoreDataList.list.Add(scoreData);

        SaveData(SceneManager.GetActiveScene().name);
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
            scoreDataList = JsonUtility.FromJson<ScoreDataList>(PlayerPrefs.GetString("scoreList"));
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
