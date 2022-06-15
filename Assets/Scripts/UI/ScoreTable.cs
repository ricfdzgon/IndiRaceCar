using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTable : MonoBehaviour
{
    [Tooltip("Referencia a la plantilla para crear las lineas con los datos de puntuacion")]
    public GameObject scoreLineTemplate;

    [Tooltip("Referencia al contenedor dentro de la lista deslizable")]
    public Transform content;
    // Start is called before the first frame update
    void Start()
    {
        if (scoreLineTemplate == null)
        {
            Debug.Log("ScoreTable.Start La referencia a scoreLineTemplate no está establecida");
        }

        if (content == null)
        {
            Debug.Log("ScoreTable.Start La referencia a content no está establecida");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(ScoreData scoreData)
    {
        //Añadir los nuevos datos a la lista de puntuaciones
        //GameObject newScoreLine = Instantiate(scoreLineTemplate, content);
        //newScoreLine.GetComponent<ScoreLine>().SetData(scoreData);

        //newScoreLine.SetActive(true);

        DataManager.instance.AddScore(scoreData);

        UpdateData();

    }

    public void UpdateData()
    {

        //Limpiamos el ScrollView (el objeto Content, en realidad) antes de volverla a rellenar con los datos
        //de puntuaciones
        foreach (Transform child in content)
        {
            if (child.gameObject != scoreLineTemplate)
            {
                Destroy(child.gameObject);
            }
        }

        //Recorremos la scoreDataList, para añadir un elemento de tipo ScoreLine por cada uno de sus elementos
        //al ScrollView que se muestra al usuario.
        foreach (ScoreData scoreDataItem in DataManager.instance.scoreDataList.list)
        {
            GameObject newScoreLine = Instantiate(scoreLineTemplate, content);
            newScoreLine.GetComponent<ScoreLine>().SetData(scoreDataItem);
            newScoreLine.SetActive(true);
        }

    }

}
