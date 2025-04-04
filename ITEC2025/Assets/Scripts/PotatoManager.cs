using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoManager : MonoBehaviour
{
    public GameObject[] objects; // Assign your 3 objects in the Inspector

    private int currentIndex = 0;

    void Start()
    {
        SetActiveObject(currentIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchTo(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchTo(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchTo(2);
        }
    }

    void SwitchTo(int newIndex)
    {
        if (newIndex == currentIndex || newIndex < 0 || newIndex >= objects.Length)
            return;

        Vector3 currentPosition = objects[currentIndex].transform.position;

        // Disable current
        objects[currentIndex].SetActive(false);

        // Enable new and move it to previous position
        objects[newIndex].transform.position = currentPosition;
        objects[newIndex].SetActive(true);

        currentIndex = newIndex;
    }

    void SetActiveObject(int index)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == index);
        }
    }
}
