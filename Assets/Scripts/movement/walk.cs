using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.VisualScripting.Member;
using static UnityEngine.EventSystems.EventTrigger;

public class Walk : MonoBehaviour
{
    

    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    public AudioSource Quarto;
    public AudioSource Cozinha;
    public AudioSource Banheiro;

    String currentRoom;

    PlayerController controls;

    private void Awake()
    {
        controls = new PlayerController();
        controls.Gameplay.Localizar.performed += ctx => LocalizarPersonagem();
    }

    void Update()
    {

        ProcessInputs();

        if(moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0,0,angle);
        }

    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("MoveHorizontal");
        float moveY = Input.GetAxisRaw("MoveVertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bedroomFloor")
        {
            currentRoom = "quarto";
        }
        else if(collision.gameObject.tag == "floor")
        {
            currentRoom = "cozinha";
        }else if(collision.gameObject.tag =="bathroomFloor")
        {
            currentRoom = "banheiro";
        }
    }


    void LocalizarPersonagem()
    {
        if(currentRoom == "quarto")
        {
            Quarto.Play();
        }
        else if (currentRoom =="cozinha")
        {
            Cozinha.Play();
        }
        else if (currentRoom== "banheiro")
        {
            Banheiro.Play();
        }

    }


}