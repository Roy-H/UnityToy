using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// DialogOpen
/// Text|this is a text dialog|talkerId|faceId
/// </summary>



public class InteractResolver : MonoBehaviour
{

    InteractBase mInteractObj;

    private IEnumerator Resolve()
    {
        string source = mInteractObj.GetInteractText();
        if (string.IsNullOrEmpty(source))
            yield break;


        StartCoroutine( Accept(source));
    }

    private IEnumerator Accept(string source)
    {
        var tokens = source.Split('\n');
        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == "DialogOpen")
            {
                yield return StartCoroutine(OpenDialogBox());
            }
            else if (tokens[i] == "DialogClose")
            {
                yield return StartCoroutine(CloseDialogBox());
            }
        }
    }

    private IEnumerator OpenDialogBox()
    {
        throw new NotImplementedException();
    }

    private IEnumerator TextDisplay(string text)
    {
        throw new NotImplementedException();
    }

    private IEnumerator CloseDialogBox()
    {
        throw new NotImplementedException();
    }


}
