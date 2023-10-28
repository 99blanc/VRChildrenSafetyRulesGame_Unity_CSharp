using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    public GameObject world;
    public GameObject[] checkPoint;
    public GameObject boardUI;
    public GameObject clearUI;
    public GameObject failUI;
    public float clearDelay = 8f;

    public int total;
    private int checkPointSize;
    private int checkPointConfirm = 0;

    private GameObject hitObject;
    public bool isDelaying = false;
    public bool isCrashing = false;
    public bool isGrabing = false;
    public bool connect;
    public float stayTime = 5f;
    private float addTime;

    private void Start()
    {
        total = checkPointSize = checkPoint.Length;
        addTime = stayTime;
    }

    private void Update()
    {
        DestroyCheck();
    }

    private void OnTriggerEnter(Collider hit)
    {
        try
        {
            if (!hit.GetComponent<UIConnect>().ConnectUI.gameObject.activeSelf)
            {
                hit.GetComponent<UIConnect>().ConnectUI.gameObject.SetActive(true);
            }
        }
        catch (NullReferenceException)
        {

        }
        if (hit.transform.tag.Equals("Clear"))
        {
            checkPointConfirm++;
            total -= checkPointConfirm;
            hit.gameObject.SetActive(false);

            if (checkPointConfirm == checkPointSize)
            {
                StartCoroutine(ShowUIDelay());
            }
        }
        if (hit.transform.tag.Equals("Check"))
        {
            if (!isDelaying && !isGrabing)
            {
                isDelaying = true;
                hitObject = hit.gameObject;
            }
        }
        if (hit.transform.tag.Equals("Car"))
        {
            isCrashing = true;
        }
    }

    private void OnTriggerStay(Collider hit)
    {
        if (hit.transform.tag.Equals("Check"))
        {
            if (!isDelaying && isGrabing && connect)
            {
                isDelaying = true;
                hitObject = hit.gameObject;
            }
            if (isDelaying && isGrabing && !connect)
            {
                isDelaying = false;
                hitObject = null;
            }
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.transform.tag.Equals("Check"))
        {
            if (isDelaying && !isGrabing)
            {
                isDelaying = false;
                hitObject = null;
            }
            if (isDelaying && isGrabing && !connect)
            {
                isDelaying = false;
                hitObject = null;
            }
        }
    }

    private void DestroyCheck()
    {
        if (isDelaying)
        {
            if (world != null)
            {
                if (!world.GetComponent<RoundControl>().isDelaying)
                {
                    if (addTime <= 0)
                    {
                        hitObject.SetActive(false);
                    }

                    addTime -= Time.deltaTime;
                }
            }
        }
        else
        {
            addTime = stayTime;
        }
    }

    private IEnumerator ShowUIDelay()
    {
        yield return new WaitForSeconds(clearDelay);

        ShowClearUI();
    }

    private void ShowClearUI()
    {
        if (failUI != null)
        {
            if (!failUI.gameObject.activeSelf)
            {
                boardUI.SetActive(false);
                clearUI.SetActive(true);
            }
        }
        else
        {
            boardUI.SetActive(false);
            clearUI.SetActive(true);
        }
    }
}
