using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemControl : MonoBehaviour
{
    public Material matOne;
    public Material matTwo;
    private LineRenderer LaserPointer;

    private void Start()
    {
        LaserPointer = GameObject.Find("LaserPointer").GetComponent<LineRenderer>();

        if (PlayerPrefs.GetInt("Cursor") == 0)
        {
            LaserPointer.material = new Material(matOne);
        }
        else if (PlayerPrefs.GetInt("Cursor") == 1)
        {
            LaserPointer.material = new Material(matTwo);
        }
    }

    private void Update()
    {
        if (LaserPointer.material == null)
        {
            if (PlayerPrefs.GetInt("Cursor") == 0)
            {
                LaserPointer.material = new Material(matOne);
            }
            else if (PlayerPrefs.GetInt("Cursor") == 1)
            {
                LaserPointer.material = new Material(matTwo);
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("Cursor") == 0)
            {
                LaserPointer.material = new Material(matOne);
            }
            else if (PlayerPrefs.GetInt("Cursor") == 1)
            {
                LaserPointer.material = new Material(matTwo);
            }
        }
    }
}
