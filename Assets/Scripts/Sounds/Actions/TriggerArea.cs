using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using XInputDotNetPure;

public class TriggerArea : MonoBehaviour
{
    private float timer = 0f;
    private bool vibrar = false;


    AudioSource source;
    Collider2D soundTrigger;

    PlayerController controls;

    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    

    public bool podeChamar;

    void Awake()
    {
        controls = new PlayerController();
        controls.Gameplay.Interagir.performed += ctx => InteragirLocal();

        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (vibrar)
        {
            GamePad.SetVibration(playerIndex, 1f, 1f);
            timer += Time.deltaTime;

            if (timer >= .5f)
            {
                GamePad.SetVibration(playerIndex, 0f, 0f);
                timer = 0f;
                vibrar = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            
            vibrar = true;
            podeChamar = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            
            podeChamar = false;
        }
    }

    void InteragirLocal()
    {
        if(podeChamar) 
        {
            source.Play();
            Destroy(this);
            
        }
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

}
