using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    public GameObject[] checkPoint;
    public GameObject gate;
    public Canvas gateUI;

    private int checkPointSize;
    private int checkPointConfirm = 0;
    private bool isChecking = false;

    private void Start()
    {
        checkPointSize = checkPoint.Length;
    }

    private void Update()
    {
        CheckPointCheck();
    }

    private void CheckPointCheck()
    {
        if (!isChecking)
        {
            for (int i = 0; i < checkPoint.Length; ++i)
            {
                if (!checkPoint[i].activeSelf)
                {
                    checkPointConfirm++;
                }
            }

            if (checkPointConfirm == checkPointSize)
            {
                isChecking = true;
                if (gate != null)
                {
                    gate.SetActive(false);
                }
                gateUI.gameObject.SetActive(true);
            }
            else
            {
                checkPointConfirm = 0;
            }
        }
    }
}
