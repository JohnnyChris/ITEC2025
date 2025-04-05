using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneReset : MonoBehaviour
{
    private Vector3 offset = Vector3.zero;

    void Awake()
    {
        offset = transform.localPosition;
    }

    public void ResetToInitialOffset()
    {
        transform.localPosition = offset;
    }

    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            ResetToOffset();
    }
    */
}
