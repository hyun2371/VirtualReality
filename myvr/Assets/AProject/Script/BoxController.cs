using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BoxController : MonoBehaviour
{
    public GameObject Pivot;
    public GameObject guideTmp;
    public GameObject JemGroup;
   

    private void OnTriggerEnter(Collider other)
    {
        Pivot.GetComponent<Animator>().SetInteger("INT", 1);

    }
    private void OnTriggerExit(Collider other)
    {
        Pivot.GetComponent<Animator>().SetInteger("INT", 2);

    }
    private void Update()
    {
        if (Pivot.GetComponent<Animator>().GetBool("isOpened"))
        {
            guideTmp.SetActive(true);
            JemGroup.SetActive(true);
           ;
        }
        else
        {
            guideTmp.SetActive(false);
            JemGroup.SetActive(false);
        }
    }
}
