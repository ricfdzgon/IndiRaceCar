using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MultiplayerUIPausa : MonoBehaviour
{
    public Canvas menuPausa;
    public Canvas menuFinal;
    public TextMeshProUGUI nombreGanador;

    public static MultiplayerUIPausa instance;
    void Start()
    {
        menuPausa.enabled = false;
        menuFinal.enabled = false;
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                menuPausa.enabled = true;
            }
            else
            {
                Time.timeScale = 1;
                menuPausa.enabled = false;
            }
        }
    }

    public void Continuar()
    {
        Time.timeScale = 1;
        menuPausa.enabled = false;
    }

    public void ReiniciarPantalla()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        menuPausa.enabled = false;
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        menuPausa.enabled = false;
    }

    public void MenuFinal(double time)
    {
        menuPausa.enabled = false;
    }

    public void FinalizarPantalla(string cocheGanador)
    {
        Time.timeScale = 0;
        menuPausa.enabled = false;
        menuFinal.enabled = true;
        nombreGanador.text = cocheGanador;

        if (cocheGanador.Equals("Coche Amarillo"))
        {
            nombreGanador.color = Color.yellow;
        }
        else
        {
            nombreGanador.color = Color.red;
        }
    }

}
