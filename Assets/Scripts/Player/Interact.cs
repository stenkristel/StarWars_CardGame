using System;
using System.Collections;
using System.Collections.Generic;
using BaseGame.Interfaces;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private IInteractable _interactable;
    private void FixedUpdate()
    {
        _interactable = CheckInteractable();
        if (_interactable == null) return;
        Debug.Log(_interactable);
    }

    private IInteractable CheckInteractable()
    {
        Ray screenToCursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(screenToCursorRay, out var hitInfo))
        {
            var hitObject = hitInfo.collider.gameObject;
            var interactable =  hitObject.GetComponent<IInteractable>();
            return interactable;
        }
        return null;
    }
}
