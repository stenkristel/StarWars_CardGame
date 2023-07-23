using BaseGame.Interfaces;
using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Board
{
    public class RowInteraction : MonoBehaviour, IInteractable
    {
        public GameObject GameObject => gameObject;

        private bool _selected;
        public bool IsSelected { get; set; }
        public bool IsOnlySelectableByObject => true;

        public bool CheckForSelectedInteraction(IInteractable interactableObject){return false;}

        public void OnStopHover()
        {
        }

        public void OnHover()
        {
        }

        public void OnSelectedInteract(IInteractable interactedObject)
        {
        }
        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                IsSelected = !IsSelected;
            }
        }
    }
}
