using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueEffect : MonoBehaviour
{
    public Text description;
    public float dialogueDelay = 0.05f;
    public bool isHiding;

    private string dialogue;

    private void Start()
    {
        dialogue = description.text;
        StartCoroutine(DialogueCoroutine(dialogue));
    }

    IEnumerator DialogueCoroutine(string text)
    {
        description.text = null;

        for (int i = 0; i < text.Length; ++i)
        {
            description.text += text[i];

            yield return new WaitForSeconds(dialogueDelay);
        }

        if (description.text.Equals(text) && isHiding)
        {
            yield return new WaitForSeconds(5f);

            GetComponentInParent<Canvas>().gameObject.SetActive(false);
        }
    }
}
