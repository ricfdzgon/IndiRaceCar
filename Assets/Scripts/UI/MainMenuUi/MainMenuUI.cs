using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject principal;
    public GameObject unjugador;

    void Start()
    {
        VolverAPrincipal();
    }

    public void UnJugadorOnClick()
    {
        principal.SetActive(false);
        unjugador.SetActive(true);
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

    public void VolverAPrincipal()
    {
        principal.SetActive(true);
        unjugador.SetActive(false);
    }
}
