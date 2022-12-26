using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon_Controller : MonoBehaviour
{
    public GameObject Canvas1;
    public GameObject Canvas2;

    private void OnTriggerEnter(Collider other)
    {
        Canvas1.SetActive(true);
        Canvas2.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Canvas1.SetActive(false);
        Canvas2.SetActive(false);
    }

}
