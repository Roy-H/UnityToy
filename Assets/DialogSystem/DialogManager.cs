using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public struct TextStruct
{
    public string Text;
    public string FaceId;
    public string SpeakerId;
}

public class DialogManager : MonoBehaviour
{
    public Transform DialogBox;
    public Text DialogText;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator OpenDialog()
    {

        DialogBox.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.08f);
    }

    public IEnumerator CloseDialog()
    {
        DialogText.text = string.Empty;
        DialogBox.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.08f);
    }

    public IEnumerator SetText(string text)
    {
        DialogText.text = string.Empty;
        bool isRapidMode = false;
        int count = 0;
        while (count <= text.Length)
        {
            DialogText.text = text.Substring(0, count);
            count++;
            if (isRapidMode)
            {
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                yield return new WaitForSeconds(0.02f);
            }
            if (Input.GetButtonDown("Jump"))
            {
                isRapidMode = true;
            }
        }
        while (true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                yield break;
            }
            yield return null;
        }
    }

    public IEnumerator SetText(TextStruct data)
    {
        DialogText.text = string.Empty;
        bool isRapidMode = false;
        int count = 0;
        while (count <= data.Text.Length)
        {
            DialogText.text = data.Text.Substring(0, count);
            count++;
            if (isRapidMode)
            {
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                yield return new WaitForSeconds(0.02f);
            }
            if (Input.GetButtonDown("Jump"))
            {
                isRapidMode = true;
            }
        }
        while (true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                yield break;
            }
            yield return null;
        }
    }
}
