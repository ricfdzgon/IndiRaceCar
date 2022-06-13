using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICoche : MonoBehaviour
{
    public TextMeshProUGUI marchaTexto;
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


}
