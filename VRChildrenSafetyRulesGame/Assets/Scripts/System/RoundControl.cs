using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundControl : MonoBehaviour
{
    public GameObject player;

    public Canvas boardUI;
    public Canvas clearUI;
    public Canvas failUI;
    public float showDelay;

    public bool useTimer;
    public Canvas timerUI;
    public float setTime;

    public bool isDelaying = false;
    private float addTime;
    private float removeTime;
    private string timerText;

    private void Start()
    {
        addTime = setTime;
        if (timerUI != null )
        {
            timerText = timerUI.GetComponentInChildren<Text>().text;
        }
    }

    private void Update()
    {
        StartTimer();
    }

    private void StartTimer()
    {
        if (!GetComponent<WallControl>().gate.activeSelf)
        {
            addTime += Time.deltaTime;
        }
        if (useTimer && timerUI != null)
        {
            if (addTime == setTime)
            {
                timerUI.gameObject.SetActive(true);
                timerUI.GetComponentInChildren<Text>().text = timerText + ((int)addTime).ToString();
            }
            if (!isDelaying)
            {
                if (failUI.gameObject.activeSelf)
                {
                    isDelaying = true;
                    timerUI.GetComponentInChildren<Text>().text = timerText + (0).ToString();
                }
                if (addTime <= 0)
                {
                    isDelaying = true;
                    timerUI.GetComponentInChildren<Text>().text = timerText + (0).ToString();
                    StartCoroutine(ActiveFail());
                }
                else
                {
                    if (player != null)
                    {
                        if (player.GetComponent<PlayerCollider>().total <= 0)
                        {
                            isDelaying = true;
                            StartCoroutine(ActiveClear());
                        }
                    }

                    addTime -= Time.deltaTime;
                    timerUI.GetComponentInChildren<Text>().text = timerText + ((int)addTime).ToString();
                }
            }
        }
    }

    private IEnumerator ActiveClear()
    {
        yield return new WaitForSeconds(showDelay);

        StopAllCoroutines();

        if (!failUI.gameObject.activeSelf)
        {
            boardUI.gameObject.SetActive(false);
            clearUI.gameObject.SetActive(true);
        }
    }

    private IEnumerator ActiveFail()
    {
        yield return new WaitForSeconds(showDelay);

        StopAllCoroutines();

        if (!clearUI.gameObject.activeSelf)
        {
            boardUI.gameObject.SetActive(false);
            failUI.gameObject.SetActive(true);
        }
    }
}
