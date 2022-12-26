using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdSound : MonoBehaviour
{
    public AudioSource bird;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bird.Play();
        }
    }
}
