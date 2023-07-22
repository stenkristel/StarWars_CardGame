using BaseGame.Interfaces;
using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Board
{
    public class RowInteraction : MonoBehaviour, IInteractable
    {
        public GameObject GameObject => gameObject;

        public bool Selected => false;

        public bool CheckForSelectedInteraction(IInteractable interactableObject){return false;}

        public bool Selectable => false;
        public PlayerInteraction PlayerInteraction { get; set; }


        public UnityEvent interact = new UnityEvent();
        public UnityEvent<GameObject> interacts = new UnityEvent<GameObject>();

        public void OnStopHover()
        {
        }

        public void OnHover()
        {
        }

        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) interacts.Invoke(gameObject);
        }
    }
}
