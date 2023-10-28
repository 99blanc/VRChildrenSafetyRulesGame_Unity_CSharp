using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoundUI : MonoBehaviour
{
    public GameObject showUI;
    public float showUIDelay = 7f;
    private bool hitCheck = false;

    private void Update()
    {
        if (!hitCheck)
        {
            hitCheck = true;
            StartCoroutine(ShowUI());
        }
    }

    private IEnumerator ShowUI()
    {
        yield return new WaitForSeconds(showUIDelay);

        hitCheck = false;
        gameObject.SetActive(false);
    }
}
