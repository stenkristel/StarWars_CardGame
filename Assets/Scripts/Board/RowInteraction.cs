using BaseGame.Interfaces;
using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Board
{
    public class RowInteraction : MonoBehaviour, IInteractable
    {
        public GameObject GameObject => gameObject;
    
        private bool _isSelectable = false;
        public bool IsSelectable => _isSelectable;

        public bool Selectable => false;
        public PlayerInteraction PlayerInteraction { get; set; }


        public UnityEvent interact = new UnityEvent();
        public UnityEvent<GameObject> interacts = new UnityEvent<GameObject>();
        public void OnHover()
        {
            
        }

        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) interacts.Invoke(gameObject);
        }
    }
}
