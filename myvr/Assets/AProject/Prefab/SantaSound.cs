using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaSound : MonoBehaviour
{
    public AudioSource santa;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            santa.Play();
        }
    }

  
}
