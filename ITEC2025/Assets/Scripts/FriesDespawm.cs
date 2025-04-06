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
        yield return new WaitForSeconds(4f);

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.2f);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f); ;
            yield return new WaitForSeconds(0.2f);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f); ;
        }
        
        Destroy(gameObject);
    }
}
