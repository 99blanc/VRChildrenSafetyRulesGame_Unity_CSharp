using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSound : MonoBehaviour
{
    public Canvas clearUI;
    public Canvas failUI;
    private bool sound = false;

    private void Update()
    {
        if (clearUI != null && clearUI.gameObject.activeSelf && !sound)
        {
            SoundControl.instance.PlaySE("Clear");
            sound = true;
        }
        if (failUI != null && failUI.gameObject.activeSelf && !sound)
        {
            SoundControl.instance.PlaySE("Fail");
            sound = true;
        }
    }
}
