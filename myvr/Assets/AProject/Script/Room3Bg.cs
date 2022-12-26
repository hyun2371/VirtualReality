using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3Bg : MonoBehaviour
{
    public AudioSource bg3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bg3.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            bg3.Stop();
        }
    }
}
