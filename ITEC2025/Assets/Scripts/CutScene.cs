using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CutScene : MonoBehaviour
{

    public GameObject bird;
    public AudioSource audioSource;
    Animator animator;
    public GameObject potato;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = bird.GetComponent<Animator>();
    }


    private void Start()
    {
        StartCoroutine(cutScene());
    }

    IEnumerator cutScene()
    {
        //yield return new WaitForSeconds(0.5f);
        audioSource.Play();
        yield return new WaitForSeconds(16f);
        audioSource.Stop();
        animator.Play("Wand");
        yield return new WaitForSeconds(1f);
        animator.Play("chick_idle");
        potato.SetActive(true);
    }
}
