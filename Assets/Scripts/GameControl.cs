using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    // Declarar todas Las propiedades para poderlas acceder desde Game controller
    static public GameControl Instance;
    public GameObject birdBehaviour; // Gestionar pájaros
    public PlayerControl playerControl; // Gestionar jugador
    public UIController uiController; // Gestionar canvas
    public SFXManager sfxManager; // Gestinonar sonido

    public int pointsToWin = 15; // Puntos para ganar (modificar desde unity)

    private void Awake()
    {
        PlayerPrefs.SetInt("PointsToWin", pointsToWin);
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void CheckGameOver()
    {
        // Guardar la puntuacion en las preferencias de jugador
        int score = uiController.GetScore();
        PlayerPrefs.SetInt("score", score);

        if (score >= pointsToWin)
        {
            ActiveEndScene();
        }
    }

    // Cargar la escena final
    public void ActiveEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }


}
