using BaseGame.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        private IInteractable _interactable;

        private void Update()
        {
            _interactable = CheckInteractable();
            if (_interactable == null) return;
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
            _interactable.OnHover();
            _interactable.Interact();
        }
    }
}

