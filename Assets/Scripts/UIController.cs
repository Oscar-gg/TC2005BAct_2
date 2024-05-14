using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{

    public Text ammountPoints;
    string ammountText = "Points: "; // Texto inicial
    int currentScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        ActiveScore();
    }

    // Inicializar texto inicial
    public void ActiveScore()
    {
        ammountPoints.text = ammountText + "--";
    }

    // Agregar puntuaci�n
    public void AddPoints(int _points)
    {
        currentScore += _points;
        PrintScore();
    }

    // Actualizar el texto, considerando la puntuaci�n
    public void PrintScore()
    {
        ammountPoints.text = ammountText + currentScore.ToString();
    }

    // Getter para obtener puntuaci�n
    public int GetScore()
    {
        return currentScore;
    }
}
