using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICoche : MonoBehaviour
{
    public TextMeshProUGUI marchaTexto;
    public TextMeshProUGUI velocidadTexto;
    public TextMeshProUGUI temporizadorTexto;
    public static UICoche instance;
    void Start()
    {
        instance = this;
    }

    public void CambiarTextoMarcha(float marcha)
    {
        switch (marcha)
        {
            case 1:
                marchaTexto.text = "1";
                break;
            case 0:
                marchaTexto.text = "N";
                break;
            case -1:
                marchaTexto.text = "R";
                break;
        }
    }

    public void CambiarTextoVelocidad(float velocidad)
    {
        velocidad = (int)velocidad * 3;
        velocidadTexto.text = velocidad.ToString();
    }

    public void UpdateTemporizador(float temporizador)
    {
        double temporizadortext = System.Math.Round(temporizador, 2);
        if (temporizador < 999)
        {
            temporizadorTexto.text = temporizadortext.ToString();
        }
    }
}
