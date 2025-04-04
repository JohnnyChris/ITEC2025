using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{

    public Image[] potatoImages;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            potatoImages[0].enabled = true;
            potatoImages[1].enabled = false;
            potatoImages[2].enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            potatoImages[1].enabled = true;
            potatoImages[0].enabled = false;
            potatoImages[2].enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            potatoImages[2].enabled = true;
            potatoImages[0].enabled = false;
            potatoImages[1].enabled = false;
        }
    }
}
