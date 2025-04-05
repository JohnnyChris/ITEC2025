using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForkScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Animator animator = collision.gameObject.GetComponent<Animator>();
            animator.SetTrigger("touchedFork");
            StartCoroutine(ReloadSceneCoroutine());
        }
        if (collision.gameObject.tag == "MashedPlayer")
        {
            GameObject bone = GameObject.FindGameObjectWithTag("spawnBone");
            Vector3 lastPosition = bone.transform.position;

            // Set the position of the parent directly
            Transform parent = collision.gameObject.transform.parent;
            if (parent != null)
            {
                parent.position = lastPosition;

                Animator animator = parent.GetComponent<Animator>();

                
                    animator.SetTrigger("touchedFork");
                

                StartCoroutine(ReloadSceneCoroutine());
            }
        }
        Debug.Log("#######");
        Debug.Log(collision.gameObject.tag);

    }

    private IEnumerator ReloadSceneCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
