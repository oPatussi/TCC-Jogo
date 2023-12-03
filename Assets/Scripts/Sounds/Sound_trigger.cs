using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_trigger : MonoBehaviour
{

    AudioSource source;
    Collider2D soundTrigger;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "floor")
        {
            source.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        source.Stop();
    }



}
