using System.Collections.Generic;
using BaseGame.Interfaces;
using Player;
using UnityEditor.MemoryProfiler;
using UnityEngine;

namespace Cards.Base
{
    public class CardInteract : MonoBehaviour, IInteractable
    {
        public GameObject GameObject => gameObject;
        
        private bool _selected;
        private PlayerInteraction _playerInteraction;
        public PlayerInteraction PlayerInteraction { get; set; }
        public bool Selectable => true;


        private bool Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                Vector3 scaleChange = _selected ? new Vector3(0.2f, 0.2f, 0) : new Vector3(-0.2f, -0.2f, 0);
                gameObject.transform.localScale += scaleChange;
                if (value)
                {
                    OnSelected();
                }
                
            }
        }

        public void OnHover()
        {
            
        }

        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Selected = !Selected;
            }
        }
        

        private void OnSelected()
        {
            _playerInteraction.IsSelected = true;
        }

        private void Update()
        {
            if (!Selected) return;
            if (PlayerInteraction.Interactable.GameObject.CompareTag("row"))
            {
                Debug.Log("Row!");
            }
        }
        
        public void Play()
        {
            
        }
    }
}
