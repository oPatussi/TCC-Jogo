using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_trigger : MonoBehaviour
{

    AudioSource source;
    Collider2D soundTrigger;

    public bool Batendo;
    public bool entrou;

    private void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            Batendo = !Batendo;

            if (Batendo == false)
            {
                source.Stop();
            }
        }

 
        if (Batendo == true && entrou == true)
        {
            source.loop = true;
            source.Play();
        }

    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Bengala")
        {
            entrou = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bengala")
        {
            entrou = false;
        }
    }

}
