using System;
using System.Threading;
using BaseGame.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        private IInteractable _interactableObject;

        private IInteractable _selected;
        public IInteractable SelectedObject { get; set; }

        private void Update()
        {
            _interactableObject = CheckInteractable();
            if (_interactableObject == null) return;
            if (_interactableObject.Selected) //looks if the interactable object has been selected
            {
                SelectedInteract();
                return;
            }
            Interact();
        }

        private IInteractable CheckInteractable()
        {
            IInteractable interactable = CastRayToInteractable();
            if (interactable != _interactableObject && _interactableObject != null) _interactableObject.OnStopHover();
            return interactable;
        }

        private IInteractable CastRayToInteractable() //Looks if the cursor is on a object it can interact with and save the interactable object
        {
            Ray screenToCursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(screenToCursorRay, out var hitInfo)) return null;
            
            var hitObject = hitInfo.collider.gameObject;
            var interactable = hitObject.GetComponent<IInteractable>();
            return interactable;
        }

        private void Interact()
        {
            _interactableObject.Interact();
            _interactableObject.OnHover();
            Debug.Log("CAN INTERACT");
        }
        
        private void SelectedInteract()
        {
            SelectedObject ??= _interactableObject; //Saves the selected object separately from the interactable object
            if (SelectedObject.CheckForSelectedInteraction(_interactableObject)) _interactableObject.OnHover(); //Sees if the selected object can interact with the object the player is hovering on
        }
    }
}

