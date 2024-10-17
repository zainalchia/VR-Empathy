using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectInteractable
{
    bool ShouldInteractWithFace();
    void SetInteractive(bool trueOrFalse);
    void OnInteract();

}
