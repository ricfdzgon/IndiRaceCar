using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIPausa : MonoBehaviour
{
    public Canvas menuPausa;
    public Canvas menuFinal;
    public TextMeshProUGUI tiempoFinal;
    public GameObject botonesMenuFinal;

    public static UIPausa instance;
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
        menuFinal.enabled = true;
        menuPausa.enabled = false;
        botonesMenuFinal.SetActive(false);
        tiempoFinal.text = time.ToString();
    }

    public void CargarDatos()
    {
        botonesMenuFinal.SetActive(true);
    }
}
