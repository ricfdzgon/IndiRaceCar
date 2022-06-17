using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerSceneManager : MonoBehaviour
{
    public static MultiplayerSceneManager instance;
    private float totalTime;
    public List<GameObject> efectosFinales = new List<GameObject>();
    void Start()
    {
        Time.timeScale = 1;
        instance = this;
        totalTime = 0;
    }
    public void CargarEfectosFinales()
    {
        foreach (GameObject efecto in efectosFinales)
        {
            efecto.SetActive(true);
        }
    }
}
