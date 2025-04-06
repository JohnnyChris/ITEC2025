using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class potatoAnim : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -8.95f)
        {
            gameObject.transform.position += new Vector3(0, 2) * Time.deltaTime;
        }
        else
        {
            StartCoroutine(cutScene());

        }
    }

    IEnumerator cutScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }

}
