using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundList : MonoBehaviour
{
    public static RoundList instance;

    public Canvas chapter;
    public Canvas round;
    public Canvas about;

    public RawImage earthquake;
    public RawImage traffic;
    public RawImage fire;

    public Button Round1;
    public Button Round2;
    public Button Round3;

    public int pageContents = 3;
    public int startPage = 1;
    public int endPage = 2;
    private int currentPage;
    private int[] currentRound;

    private string roundName;
    private string[] roundText;

    private const int EARTHQUAKE = 1, TRAFFIC = 2, FIRE = 3;

    public void ActiveAbout(bool active)
    {
        SoundControl.instance.PlaySE("Click");
        about.gameObject.SetActive(active);
    }

    public void ActivePage(bool active)
    {
        SoundControl.instance.PlaySE("Click");
        chapter.gameObject.SetActive(!active);
        round.gameObject.SetActive(active);
    }

    public void SetPage(string round)
    {
        currentPage = startPage;
        roundText = new string[pageContents * endPage];
        currentRound = new int[pageContents];
        this.roundName = round;
        ActivePage(true);
        ActiveAbout(false);

        if (roundName.Equals("Earthquake"))
        {
            earthquake.gameObject.SetActive(true);
            traffic.gameObject.SetActive(false);
            fire.gameObject.SetActive(false);
            for (int i = 0; i < pageContents * endPage; ++i)
            {
                roundText[i] = "Round" + EARTHQUAKE.ToString() + "-" + (i + 1).ToString();
            }
        }
        else if (roundName.Equals("Traffic"))
        {
            earthquake.gameObject.SetActive(false);
            traffic.gameObject.SetActive(true);
            fire.gameObject.SetActive(false);
            for (int i = 0; i < pageContents * endPage; ++i)
            {
                roundText[i] = "Round" + TRAFFIC.ToString() + "-" + (i + 1).ToString();
            }
        }
        else if (roundName.Equals("Fire"))
        {
            earthquake.gameObject.SetActive(false);
            traffic.gameObject.SetActive(false);
            fire.gameObject.SetActive(true);
            for (int i = 0; i < pageContents * endPage; ++i)
            {
                roundText[i] = "Round" + FIRE.ToString() + "-" + (i + 1).ToString();
            }
        }

        for (int i = 0; i < currentRound.Length; ++i)
        {
            currentRound[i] = i;
        }
        Round1.GetComponentInChildren<Text>().text = roundText[currentRound[0]];
        Round2.GetComponentInChildren<Text>().text = roundText[currentRound[1]];
        Round3.GetComponentInChildren<Text>().text = roundText[currentRound[2]];
    }

    public void PreviousPage()
    {
        if (currentPage > startPage)
        {
            currentPage--;
            for (int i = 0; i < currentRound.Length; ++i)
            {
                currentRound[i] -= pageContents;
            }
            Round1.GetComponentInChildren<Text>().text = roundText[currentRound[0]];
            Round2.GetComponentInChildren<Text>().text = roundText[currentRound[1]];
            Round3.GetComponentInChildren<Text>().text = roundText[currentRound[2]];
        }
    }

    public void NextPage()
    {
        if (currentPage < endPage)
        {
            currentPage++;
            for (int i = 0; i < currentRound.Length; ++i)
            {
                currentRound[i] += pageContents;
            }
            Round1.GetComponentInChildren<Text>().text = roundText[currentRound[0]];
            Round2.GetComponentInChildren<Text>().text = roundText[currentRound[1]];
            Round3.GetComponentInChildren<Text>().text = roundText[currentRound[2]];
        }
    }
    public void AboutButton()
    {
        SoundControl.instance.PlaySE("Click");

        if (!about.gameObject.activeSelf)
        {
            ActiveAbout(true);
        }
        else
        {
            ActiveAbout(false);
        }
    }

    public void RoundOneButton()
    {
        SoundControl.instance.PlaySE("Click");
        LoadControl.LoadScene(Round1.GetComponentInChildren<Text>().text.ToString());
    }

    public void RoundTwoButton()
    {
        SoundControl.instance.PlaySE("Click");
        LoadControl.LoadScene(Round2.GetComponentInChildren<Text>().text.ToString());
    }

    public void RoundThreeButton()
    {
        SoundControl.instance.PlaySE("Click");
        LoadControl.LoadScene(Round3.GetComponentInChildren<Text>().text.ToString());
    }

    public void RoundPrevButton()
    {
        SoundControl.instance.PlaySE("Click");
        PreviousPage();
    }

    public void RoundNextButton()
    {
        SoundControl.instance.PlaySE("Click");
        NextPage();
    }

    public void BackButton()
    {
        SoundControl.instance.PlaySE("Click");
        ActivePage(false);
    }

    public void EarthquakeButton()
    {
        SoundControl.instance.PlaySE("Click");
        ActivePage(true);
        SetPage("Earthquake");
    }

    public void TrafficButton()
    {
        SoundControl.instance.PlaySE("Click");
        ActivePage(true);
        SetPage("Traffic");
    }

    public void FireButton()
    {
        SoundControl.instance.PlaySE("Click");
        ActivePage(true);
        SetPage("Fire");
    }
}
