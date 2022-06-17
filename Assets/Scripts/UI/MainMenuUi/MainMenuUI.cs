using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject principal;
    public GameObject unjugador;
    public GameObject marcadores;
    public GameObject multijugadorL;

    public ScoreTable scoreTable;

    void Start()
    {
        VolverAPrincipal();
    }

    public void UnJugadorOnClick()
    {
        principal.SetActive(false);
        unjugador.SetActive(true);
    }
    public void MultijugadorLOnClick()
    {
        principal.SetActive(false);
        unjugador.SetActive(false);
        multijugadorL.SetActive(true);
    }

    public void UnJugadorOnClickLake()
    {
        SceneManager.LoadScene("race_track_lake");
    }
    public void UnJugadorOnClickNight()
    {
        SceneManager.LoadScene("scene1-night");
    }
    public void UnJugadorOnClickMountain()
    {
        SceneManager.LoadScene("Sprint Track");
    }
    public void MultijugadorLOnClickLake()
    {
        SceneManager.LoadScene("Multi_race_track_lake");
    }
    public void MultijugadorLOnClickNight()
    {
        SceneManager.LoadScene("Multi_scene1-night");
    }
    public void MultijugadorLOnClickMountain()
    {
        SceneManager.LoadScene("Multi_Sprint_Track");
    }
    public void MarcadoresOnClick()
    {
        principal.SetActive(false);
        marcadores.SetActive(true);
    }
    public void CargarDatosLake()
    {
        DataManager.instance.LoadData("race_track_lake");
        scoreTable.UpdateData();
    }
    public void CargarDatosNight()
    {
        DataManager.instance.LoadData("scene1-night");
        scoreTable.UpdateData();
    }
    public void CargarDatosSprint()
    {
        DataManager.instance.LoadData("Sprint Track");
        scoreTable.UpdateData();
    }
    public void VolverAPrincipal()
    {
        principal.SetActive(true);
        unjugador.SetActive(false);
        marcadores.SetActive(false);
        multijugadorL.SetActive(false);
    }
    public void Salir()
    {
        Application.Quit();
    }

}
