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

    public void FinalizarPantalla(double tiempo, string nombre)
    {
        //En vez de este debug tengo que guardar el nombre junto al tiempo para guardarlo en un archivo
        Debug.Log(nombre);
        Debug.Log(tiempo);
    }

}
