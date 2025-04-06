using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
    void Start()
    {
        if (MusicManager.instance != null)
        {
            MusicManager.instance.StartMusic();
        }
    }
}
