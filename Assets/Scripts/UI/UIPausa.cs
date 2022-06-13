using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPausa : MonoBehaviour
{
    public Canvas menuPausa;
    void Start()
    {
        menuPausa.enabled = false;
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
}
