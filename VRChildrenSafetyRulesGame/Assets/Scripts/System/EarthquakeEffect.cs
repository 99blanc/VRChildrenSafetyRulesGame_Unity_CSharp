using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EarthquakeEffect : MonoBehaviour
{
    public GameObject player;
    public GameObject view;
    public Canvas clearUI;
    public Canvas failUI;
    public GrabCollider grab;

    public bool isEarthquaking = true;
    public float earthquakeAmount = 3.0f;
    public float earthquakeTime = 1.0f;

    private Vector3 latestPosition;
    private Quaternion latestRotation;

    public void Start()
    {
        latestPosition = view.transform.position;
        latestRotation = view.transform.rotation;
    }

    public void Update()
    {
        StartEarthquake();
    }

    public void StartEarthquake()
    {
        if (clearUI != null && failUI != null)
        {
            if (isEarthquaking && (clearUI.gameObject.activeSelf == false && failUI.gameObject.activeSelf == false))
            {
                StartCoroutine(ActiveEarthquake(earthquakeAmount, earthquakeTime));

                if (player != null)
                {
                    if (player.GetComponent<PlayerCollider>().total == 0)
                    {
                        isEarthquaking = false;
                        StopCoroutine(ActiveEarthquake(earthquakeAmount, earthquakeTime));
                        SoundControl.instance.StopBGM("Earthquake");
                    }
                }
            }
            else
            {
                StopCoroutine(ActiveEarthquake(earthquakeAmount, earthquakeTime));
                view.transform.position = latestPosition;
                view.transform.rotation = latestRotation;
            }
        }
    }
    
    public IEnumerator ActiveEarthquake(float earthquakeAmount, float earthquakeTime)
    {
        float timer = 0;

        while (timer <= earthquakeTime)
        {
            view.transform.position = (Vector3)UnityEngine.Random.insideUnitCircle * earthquakeAmount;
            timer += Time.deltaTime;

            yield return null;
        }

        view.transform.position = new Vector3(0f, 0f, 0f);
    }
}
