using System;
using System.Threading;
using BaseGame.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : BaseCommand
    {
        private ISelectable _selectedObject;
        private bool _isSelected;

        private ISelectable SelectedObject
        {
            get => _selectedObject;
            set
            {
                if (_selectedObject != null) _selectedObject.IsSelected = false; // Update the old selected object
                _isSelected = value != null;
                _selectedObject = value;
                if (_selectedObject != null) _selectedObject.IsSelected = _isSelected; // Update the new selected object
            }
        }

        public override void Execute()
        {
            GameObject objectOnCursor = GetObjectOnCursor(); //checks if cursor is on a object
            if (objectOnCursor == null)
            {
                SelectedObject =
                    null; //if you click on nothing, while having something selected, it is no longer selected
                return;
            }

            if (_isSelected) //Is there a object selected?
            {
                if (SelectedObject
                    .IsInteractableWith(
                        objectOnCursor)) //Yes! Can the selected object interact with the clicked object?
                {
                    SelectedObject.SelectedInteractWith(objectOnCursor); //Yes! Interact with it!
                    SelectedObject = null;
                    return;
                }

                SelectedObject = null; //No! remove the selected object!
                return;
            }

            ISelectable selectable = GetSelectable(objectOnCursor); //gets ISelectable from the clicked GameObject
            if (selectable != null) //can it be selected?
            {
                SelectedObject = selectable;
                return;
            }

            //No! Maybe it can be interacted with?
            IInteractable
                interactable = GetInteractable(objectOnCursor); //gets IInteractable from the clicked GameObject
            if (interactable != null) //can it be interacted?
            {
                interactable.Interact(); //Yes? interact with it!
                return;
            }
            //No? welp, then nothing I guess
        }

        private GameObject GetObjectOnCursor()
        {
            Ray screenToCursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(screenToCursorRay, out var hitInfo)) return null;

            var hitObject = hitInfo.collider.gameObject;
            return hitObject;
        }

        private ISelectable GetSelectable(GameObject objectOnCursor)
        {
            var selectable = objectOnCursor.GetComponent<ISelectable>();
            return selectable;
        }

        private IInteractable GetInteractable(GameObject objectOnCursor)
        {
            var interactable = objectOnCursor.GetComponent<IInteractable>();
            return interactable;
        }
    }
}