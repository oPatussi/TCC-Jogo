using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sound_trigger : MonoBehaviour
{

    AudioSource source;
    Collider2D soundTrigger;

    PlayerController controls;


    public bool batendo;
    public bool entrou;


    void Awake()
    {
        controls = new PlayerController();
        controls.Gameplay.Bater.performed += ctx => 

        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Bater"))
        {
            Debug.Log("Apertou");
            batendo = !batendo;

            if (batendo && entrou)
            {
                Tocar();
            }
            else { source.Stop(); }
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Bengala")
        {
            entrou = true;
            if (batendo)
            {
                Tocar();
            }
            else { source.Stop(); }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bengala")
        {
            entrou = false;
            source.loop = false;
        }
    }

    private void Tocar()
    {
        if (!source.isPlaying)
        {
            source.Play();
            source.loop = true;
        }
     
    }

}
