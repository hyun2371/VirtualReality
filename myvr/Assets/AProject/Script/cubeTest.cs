using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class cubeTest : MonoBehaviour
{
    public GameObject textObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            textObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textObject.SetActive(false);
    }
}
