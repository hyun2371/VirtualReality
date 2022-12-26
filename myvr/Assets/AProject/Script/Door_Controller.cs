using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Controller : MonoBehaviour
{
    public GameObject Pivot;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {   
        if (other.tag == "Player")
            Pivot.GetComponent<Animator>().SetInteger("State", 1);
    }
    private void OnTriggerExit(Collider other)
    {   
        if (other.tag=="Player")
            Pivot.GetComponent<Animator>().SetInteger("State", 2);
    }
}
