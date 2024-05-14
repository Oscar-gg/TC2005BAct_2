using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip coins;
    public AudioClip endSound;

    // Poner audio de monedas o incremento de puntos
    public void GetPoints()
    {
        AudioSource.PlayClipAtPoint(coins, Camera.main.transform.position, 0.5f);

    }

    // Poner audio de que el juego finalizó
    public void EndGame()
    {
        AudioSource.PlayClipAtPoint(endSound, Camera.main.transform.position, 0.5f);
    }
}
