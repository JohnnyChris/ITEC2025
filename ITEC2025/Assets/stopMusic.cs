using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopMusic : MonoBehaviour
{
    void Start()
    {
        if (MusicManager.instance != null)
        {
            MusicManager.instance.StopMusic();
        }
    }
}
