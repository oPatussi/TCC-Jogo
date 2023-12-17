using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_trigger : MonoBehaviour
{

    AudioSource source;
    Collider2D soundTrigger;

    public bool batendo;
    public bool entrou;


    void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
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
