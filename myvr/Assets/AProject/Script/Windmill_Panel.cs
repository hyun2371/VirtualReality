using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill_Panel : MonoBehaviour
{
    public GameObject Canvas;
    private void OnTriggerEnter(Collider other)
    {   
        if (other.tag=="Player")
            Canvas.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            Canvas.SetActive(false);
    }
}
