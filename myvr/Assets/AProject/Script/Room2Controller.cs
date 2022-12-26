using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Controller : MonoBehaviour
{
    public AudioSource room2Sound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            room2Sound.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            room2Sound.Stop();
        }
    }
}
