using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriesDespawm : MonoBehaviour
{
  
    void Update()
    {
        StartCoroutine(DestroyBullet());
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
