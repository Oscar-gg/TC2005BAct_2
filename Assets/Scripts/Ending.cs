using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class Ending : MonoBehaviour
{

    public Text _title;
    public SFXManager sound;

    // Start is called before the first frame update
    void Start()
    {
        // Si los puntos son m�s que los necesarios, indicar que se gan� el juego
        if (PlayerPrefs.GetInt("score") >= GameControl.Instance.pointsToWin)
        {
            _title.text = "�Felicidades Nina, has ganado :)!";
        } else
        {
            _title.text = "Estuviste cerca nina, vuelve a intentar :0";
        }
        // Poner sonido de final
        sound.EndGame();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

}
