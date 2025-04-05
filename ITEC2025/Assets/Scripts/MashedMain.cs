using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MashedMain : MonoBehaviour
{
    private Vector3 BonesPosition()
    {
        List<Transform> bones = transform.GetComponentsInChildren<Transform>().ToList();


        bones.Remove(transform);

        Vector3 average = Vector3.zero;

        foreach (Transform t in bones)
        {
            average += t.position;
        }

        average /= bones.Count;

        return average;
    }

    public void PrepareMashedForSwitch()
    {
        Vector3 pos = BonesPosition();

        foreach (var b in transform.GetComponentsInChildren<BoneReset>().ToList())
        {
            b.ResetToInitialOffset();
        }

        transform.position = pos;
    }

    public void DestroyPotato()
    {
        Destroy(gameObject);
    }


}
