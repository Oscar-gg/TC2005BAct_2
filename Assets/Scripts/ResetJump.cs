using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetJump : MonoBehaviour
{ 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cuando hay una colisión, resetear los saltos del jugador
        collision.gameObject.GetComponent<PlayerControl>().resetJump();
    }
}
