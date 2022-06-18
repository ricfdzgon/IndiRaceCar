using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICocheMulti : MonoBehaviour
{
    public TextMeshProUGUI marchaTexto;
    public TextMeshProUGUI velocidadTexto;
    public static UICocheMulti instance;
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
}
