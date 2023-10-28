using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke : MonoBehaviour
{
    public float fireDelay = 5f;
    public GameObject blackSmoke;
    
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Fire"))
        {
            other.GetComponent<ParticleSystem>().Stop();
            blackSmoke.GetComponent<ParticleSystem>().Stop();
            StartCoroutine(ObjectActiveFalse(other));
        }
    }

    private IEnumerator ObjectActiveFalse(GameObject hit)
    {
        yield return new WaitForSeconds(5f);
        hit.SetActive(false);
    }
}
