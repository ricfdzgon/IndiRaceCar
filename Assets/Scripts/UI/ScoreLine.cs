using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLine : MonoBehaviour
{
    [Tooltip("Referencia al TMP en el que se muestra el nombre del jugador")]
    public TextMeshProUGUI nameText;

    [Tooltip("Referencia al TMP en el que se muestra la puntuación")]
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (nameText == null)
        {
            Debug.Log("ScoreLine.Start No está establecida la referencia a nameText");
        }
        if (scoreText == null)
        {
            Debug.Log("ScoreLine.Start No está establecida la referencia a scoreText");
        }
    }

    public void SetData(ScoreData scoreData)
    {
        nameText.text = scoreData.playerName;
        scoreText.text = scoreData.time.ToString();
    }

}
