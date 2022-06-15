using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObstaculos : MonoBehaviour
{
    public static ControlObstaculos instance;
    public GameObject obstaculosPrimerVuelta;
    public GameObject obstaculosSegundaVuelta;

    void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        obstaculosPrimerVuelta.SetActive(true);
        obstaculosSegundaVuelta.SetActive(false);
    }

    public void CambiarVuelta()
    {
        obstaculosPrimerVuelta.SetActive(false);
        obstaculosSegundaVuelta.SetActive(true);
    }
}
