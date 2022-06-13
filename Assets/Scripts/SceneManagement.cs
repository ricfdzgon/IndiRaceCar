using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement instance;
    private float totalTime;
    void Start()
    {
        Time.timeScale = 1;
        instance = this;
        totalTime = 0;
    }

    public void FinalizarPantalla(float tiempo)
    {
        double tiempotext = System.Math.Round(tiempo, 2);
        Debug.Log("Tiempo final" + tiempotext);
        Time.timeScale = 0;
        UIPausa.instance.MenuFinal(tiempotext);
    }

}
