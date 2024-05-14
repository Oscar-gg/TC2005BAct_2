using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{

    public BirdName nameBird = BirdName.blue;

    // Enumerador con los pájaros disponibles
    public enum BirdName
    {
        blue, chicken, yellow, eagle, owl
    }

    [Range(0, 15)] public int points = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checar si la colisión es con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Destroy(this.gameObject); // Quitar el pájaro
            GameControl.Instance.uiController.AddPoints(points); // Sumar puntos a jugador
            GameControl.Instance.CheckGameOver(); // Cambiar pantalla si es necesario
            GameControl.Instance.sfxManager.GetPoints(); // Sonido de puntos
        }
    }
}
