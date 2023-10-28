using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficEffect : MonoBehaviour
{
    public GameObject player;
    public GameObject checkPoint;
    public GameObject greenEffect;
    public GameObject redEffect;
    public Canvas boardUI;
    public Canvas clearUI;
    public Canvas failUI;

    public bool isTrafficing = true;
    public float greenLightDelay = 7f;
    public float redLightDelay = 5f;
    public bool isChecking = false;

    private void Start()
    {
        StartCoroutine(ActiveTrafficGreen());
    }

    private void Update()
    {
        TrafficCaution();

        if (isTrafficing)
        {
            if (player != null)
            {
                if (player.GetComponent<PlayerCollider>().total == 0)
                {
                    isTrafficing = false;
                    SoundControl.instance.StopBGM("Traffic");
                }
            }
        }
    }

    private void TrafficCaution()
    {
        if (isChecking) 
        {
            if (player.GetComponent<PlayerCollider>().isDelaying)
            {
                int size = player.GetComponent<PlayerCollider>().checkPoint.Length;
                GameObject[] gameobject = player.GetComponent<PlayerCollider>().checkPoint;

                for (int i = 0; i < size; ++i)
                {
                    gameobject[i].tag = "Untagged";
                }

                ShowFailUI();
            }
        }
        if (player.GetComponent<PlayerCollider>().isCrashing)
        {
            ShowFailUI();
        }
    }

    private IEnumerator ActiveTrafficGreen()
    {
        isChecking = false;
        redEffect.SetActive(false);
        greenEffect.SetActive(true);

        yield return new WaitForSeconds(greenLightDelay);

        StartCoroutine(ActiveTrafficRed());
    }

    private IEnumerator ActiveTrafficRed()
    {
        isChecking = true;
        greenEffect.SetActive(false);
        redEffect.SetActive(true);

        yield return new WaitForSeconds(redLightDelay);

        StartCoroutine(ActiveTrafficGreen());
    }

    private void ShowFailUI()
    {
        if (clearUI != null)
        {
            if (!clearUI.gameObject.activeSelf)
            {
                boardUI.gameObject.SetActive(false);
                failUI.gameObject.SetActive(true);
            }
        }
        else
        {
            boardUI.gameObject.SetActive(false);
            failUI.gameObject.SetActive(true);
        }
    }
}
