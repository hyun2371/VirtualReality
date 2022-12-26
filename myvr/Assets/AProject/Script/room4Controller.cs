using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room4Controller : MonoBehaviour
{
    public AudioSource bg4;
    public AudioSource water;
    public AudioSource bird;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bg4.Play();
            water.Play();
            bird.Play();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            bg4.Stop();
            water.Stop();
            bird.Play();
        }
    }
}
