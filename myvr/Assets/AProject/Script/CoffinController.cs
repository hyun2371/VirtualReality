using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinController : MonoBehaviour
{
    public GameObject Cover;
    private void OnTriggerEnter(Collider other)
    {   
        if (other.tag == "Player")
            Cover.GetComponent<Animator>().SetInteger("State", 1);
    }
}
