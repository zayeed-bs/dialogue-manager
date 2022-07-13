using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index = 0;

    public void Start()
    {
        StartDialogue();
    }

    public void StartDialogue()
    { 
        StartCoroutine(Type());
        Debug.Log(sentences);
    }

    IEnumerator Type()
    {
        textDisplay.text = "";
        foreach(char letter in sentences[index].ToCharArray())
        {
            if (Input.GetMouseButtonDown(0))
            {
                textDisplay.text = sentences[index];
                break;
            }

            textDisplay.text += letter;
            yield return new WaitForSeconds(0.03f);
        }

        index++;

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (index < sentences.Length)
                {
                    Debug.Log("e");
                    break;
                }
                else
                {
                    textDisplay.text = "";
                    StopCoroutine(Type());
                }
            }
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        yield return Type();
    }
}
