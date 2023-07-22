using System.Threading;
using BaseGame.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        private IInteractable _interactable;
        public IInteractable Interactable { get; }
        
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (value)
                {
                    Selected = _interactable;
                }
                _isSelected = value;
            } 
        }
        
        private IInteractable _selected;

        public PlayerInteraction(IInteractable interactable)
        {
            Interactable = interactable;
        }

        public IInteractable Selected { get; set; }

        private void Update()
        {
            _interactable = CheckInteractable();
            if (_interactable == null) return;
            if (IsSelected)
            {
                SelectedInteract();
            }
            Interact();
        }


        private IInteractable CheckInteractable()
        {
            Ray screenToCursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(screenToCursorRay, out var hitInfo))
            {
                var hitObject = hitInfo.collider.gameObject;
                var interactable = hitObject.GetComponent<IInteractable>();
                return interactable;
            }

            return null;
        }

        private void Interact()
        {
            _interactable.PlayerInteraction = gameObject.GetComponent<PlayerInteraction>();
            _interactable.OnHover();
            _interactable.Interact();
        }
        
        private void SelectedInteract()
        {
            
        }
    }
}

