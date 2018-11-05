using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMessageInteract : InteractBase
{
    [SerializeField]
    [TextArea]
    public string InteractText;

    public override string GetInteractText()
    {
        return InteractText;
    }
}
