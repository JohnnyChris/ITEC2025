using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*public class PotatoManager : MonoBehaviour
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

        // Check if current object is index 1 (object 2)
        if (currentIndex == 1)
        {
            MashedMain mashed = objects[1].GetComponent<MashedMain>();
            if (mashed != null)
            {
                mashed.PrepareMashedForSwitch();
            }
        }

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
*/
public class PotatoManager : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject[] objects; // Assign your 3 objects in the Inspector
    private GameObject currentShape;
    private int currentIndex = 0;

    void Start()
    {
        currentShape = Instantiate(objects[currentIndex], spawnPoint.transform.position, Quaternion.identity);
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
        if (currentIndex == newIndex)
        {
            return;
        }

        Vector2 currentVelocity; 
        Vector2 lastPosition;


        if (currentIndex == 1)
        {
            GameObject bone = GameObject.FindGameObjectWithTag("spawnBone");
            lastPosition = bone.transform.position;
            currentVelocity = bone.GetComponent<Rigidbody2D>().velocity;

        }
        else
        {
            currentVelocity = currentShape.GetComponent<Rigidbody2D>().velocity;
            lastPosition = currentShape.transform.position;
        }

        Destroy(currentShape);
        currentIndex = newIndex;
        objects[currentIndex].transform.position = lastPosition;
        currentShape = Instantiate(objects[currentIndex]);
        if (newIndex == 1)
        {
            List<Rigidbody2D> bones = currentShape.GetComponentsInChildren<Rigidbody2D>().ToList();
            foreach (Rigidbody2D bone in bones)
            {
                bone.velocity = currentVelocity;
            }

        }
            else {
                currentShape.GetComponent<Rigidbody2D>().velocity = currentVelocity;
            }

       
    }
}
