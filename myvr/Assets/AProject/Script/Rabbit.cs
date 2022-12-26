using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    public GameObject rabbit;
    Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Anim.SetBool("isRun", true);

    }

    private void OnTriggerExit(Collider other)
    {
        Anim.SetBool("isRun", false);
    }
}
