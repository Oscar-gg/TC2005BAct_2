using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rig; // referencia la Rigidbody del jugador
    private int jumpsRemaining = 2; // Cantidad de saltos que puede realizar 

    bool moveLeft;
    bool moveRight;
    bool moveUp;

    float horizontalMove;
    float verticalMove;

    public float speed = 4;
    public float force = 0.1f;

    public SpriteRenderer sr;
    Animator animatorController;

    // Inicializar el animator para nina
    void Start()
    {
        // Para modificar propiedades de animaciones
        animatorController = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Buttons
    public void PointerDownLeft()
    {
        moveLeft = true;
    }
    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }

    public void PointerDownUp()
    {
        moveUp = true;
    }

    public void PointerUpUp()
    {
        moveUp = false;
    }


    void Update()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
            transform.localScale = new Vector3(-1, 1);
            UpdateAnimation(PlayerAnimation.walk);
            rig.velocity = new Vector2(horizontalMove, rig.velocity.y);
        } else if (moveRight)
        {
            horizontalMove = speed;
            transform.localScale = new Vector3(1, 1);
            UpdateAnimation(PlayerAnimation.walk);
            rig.velocity = new Vector2(horizontalMove, rig.velocity.y);
        } else
        {
            UpdateAnimation(PlayerAnimation.idle);
        }

        if (moveUp)
        {
            verticalMove = force;
            UpdateAnimation(PlayerAnimation.jump);
            rig.AddForce(Vector2.up * verticalMove, ForceMode2D.Impulse);
        }

        //// Hacer un salto cuando se presiona la flecha de arriba
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    if (jumpsRemaining > 0)
        //    {
        //        rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Emular salto agregando vector de fuerza
        //        jumpsRemaining--; // Reducir cantidad de saltos disponibles
        //    }

        //}
        //// Modificar apariencia de nina, en función del movimiento
        //if (rig.velocity.x > 0)
        //{
        //    transform.localScale = new Vector3(1, 1);
        //}
        //else if (rig.velocity.x < 0)
        //{
        //    transform.localScale = new Vector3(-1, 1);
        //}
    }

    //public void FixedUpdate()
    //{
    //    // obtener la velocidad de las flechitas
    //    float xInput = Input.GetAxis("Horizontal");
    //    rig.velocity = new Vector2 (xInput * moveSpeed, rig.velocity.y);
        
    //    if (rig.velocity.y != 0)
    //    {
    //        UpdateAnimation(PlayerAnimation.jump);
    //    } else if (xInput != 0)
    //    {
    //        UpdateAnimation(PlayerAnimation.walk);
    //    } else
    //    {
    //        UpdateAnimation(PlayerAnimation.idle);
    //    }
    //}

    // Resetear saltos
    public void resetJump()
    {
        jumpsRemaining = 2;
    }

    // Definir animaciones
    public enum PlayerAnimation
    {
        idle, walk, jump, die, run
    }

    // Modificar los estados de la animación
    void UpdateAnimation(PlayerAnimation nameAnimation)
    {
        switch (nameAnimation)
        {
            case PlayerAnimation.idle:
                animatorController.SetBool("isWalking", false);
                animatorController.SetBool("isJumping", false);
                break;
            case PlayerAnimation.walk:
                animatorController.SetBool("isWalking", true);
                animatorController.SetBool("isJumping", false);
                break;
            case PlayerAnimation.jump:
                animatorController.SetBool("isWalking", false);
                animatorController.SetBool("isJumping", true);
                break;
        }
    }

}
