using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadControl : MonoBehaviour
{
    public static string nextScene;
    public float loadDelay = 1f;

    [SerializeField]
    private Image progressBar;

    private void Start()
    {
        StartCoroutine(LoadCoroutine());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        int buildIndex = SceneUtility.GetBuildIndexByScenePath(nextScene);

        if (buildIndex < 0)
        {
            SceneManager.LoadScene("Title");
        }
        else
        {
            SceneManager.LoadScene("Load");
        }
    }

    private IEnumerator LoadCoroutine()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0.0f;

        yield return new WaitForSeconds(loadDelay);

        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);

                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);

                if (progressBar.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;

                    yield break;
                }
            }
        }
    }
}
