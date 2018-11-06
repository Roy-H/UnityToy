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

    public DialogManager mDialogManager;

    private bool isBusy = false;

    private IEnumerator Resolve()
    {
        if (isBusy)
            yield break;

        string source = mInteractObj.GetInteractText();
        if (string.IsNullOrEmpty(source))
            yield break;

        isBusy = true;
        yield return StartCoroutine( Accept(source));
        isBusy = false;
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
            else if (tokens[i].StartsWith("Text"))
            {
                var values = tokens[i].Split('|');
                var data = new TextStruct() { Text = values[1], SpeakerId = values[2], FaceId = values[3] };
                yield return StartCoroutine(TextDisplay(data));
            }
        }
    }

    private IEnumerator OpenDialogBox()
    {
        yield return StartCoroutine(mDialogManager.OpenDialog());
    }

    private IEnumerator TextDisplay(TextStruct data)
    {
        yield return StartCoroutine(mDialogManager.SetText(data));
    }


    private IEnumerator CloseDialogBox()
    {
        yield return StartCoroutine(mDialogManager.CloseDialog());
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            var hits = Physics.RaycastAll(new Ray(transform.position, transform.forward), 10f, 1 << LayerMask.NameToLayer("Interaction"));
            if (hits != null && hits.Length > 0)
            {
                mInteractObj = hits[0].collider.gameObject.GetComponent<InteractBase>();
                if (mInteractObj!=null)
                {
                    StartCoroutine(Resolve());
                }
            }
        }
    }

}
