using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ovr_player : MonoBehaviour
{
    TextMeshProUGUI resourceText;
    public GameObject cubeText;
    public GameObject potion1;
    public GameObject potion2;
    // Start is called before the first frame update
    void Start()
    {
        resourceText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
       if (OVRInput.GetDown(OVRInput.Button.One))
        {
            cubeText.SetActive(true);
            resourceText.text = "one button downµÊ";
            potion1.SetActive(true);
            
        }
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            cubeText.SetActive(true);
            resourceText.text = "X button downµÊ";
            potion2.SetActive(true);

        }
        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            cubeText.SetActive(false);
            potion1.SetActive(false);
        }
    }
}
