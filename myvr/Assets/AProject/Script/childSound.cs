using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childSound : MonoBehaviour
{
    public AudioSource child;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            child.Play();
        }
    }
}
