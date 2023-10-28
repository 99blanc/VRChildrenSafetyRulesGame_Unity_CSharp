using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetList : MonoBehaviour
{
    public Material matOne;
    public Material matTwo;
    public Scrollbar backgroundmusicsound;
    public Scrollbar effectsound;
    public Toggle toggle;
    public Canvas OptionUI;
    public Canvas SetUpUI;
    public LineRenderer LaserPoint;

    public void Start()
    {
        backgroundmusicsound.value = PlayerPrefs.GetFloat("BGM");
        effectsound.value = PlayerPrefs.GetFloat("Effect");
        toggle.isOn = PlayerPrefs.GetInt("Cursor") == 0 ? true : false;
    }

    public void Update()
    {
        CursorChange();
    }

    public void CursorChange()
    {
        if (toggle.isOn)
        {
            LaserPoint.material = new Material(matOne);
        }
        else
        {
            LaserPoint.material = new Material(matTwo);
        }

        for (int i = 0; i < FindObjectOfType<SoundControl>().audioSourceEffects.Length; ++i)
        {
            FindObjectOfType<SoundControl>().audioSourceEffects[i].volume = effectsound.value;
        }

        for (int i = 0; i < FindObjectOfType<SoundControl>().otherEffects.Length; ++i)
        {
            FindObjectOfType<SoundControl>().otherEffects[i].volume = effectsound.value;
        }

        FindObjectOfType<SoundControl>().audioSourceBackground.volume = backgroundmusicsound.value;
    }

    public void ActiveSetUp()
    {
        OptionUI.gameObject.SetActive(false);
        SetUpUI.gameObject.SetActive(true);
    }

    public void ActiveTitle()
    {
        LoadControl.LoadScene("Title");
    }

    public void ActiveSave()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("Cursor", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Cursor", 1);
        }

        PlayerPrefs.SetFloat("BGM", backgroundmusicsound.value);
        PlayerPrefs.SetFloat("Effect", effectsound.value);
    }
}
