using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public void TitleButton()
    {
        SoundControl.instance.PlaySE("Click");
        LoadControl.LoadScene("Title");
    }

    public void OptionButton()
    {
        SoundControl.instance.PlaySE("Click");
        LoadControl.LoadScene("Option");
    }

    public void QuitButton()
    {
        SoundControl.instance.PlaySE("Click");
        Application.Quit();
    }

    public void SetButton()
    {
        SoundControl.instance.PlaySE("Click");
        LoadControl.LoadScene("Title");
    }
}
