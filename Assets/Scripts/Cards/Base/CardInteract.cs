using System.Collections.Generic;
using BaseGame.Interfaces;
using Player;
using Unity.VisualScripting;
using UnityEditor.MemoryProfiler;
using UnityEngine;

namespace Cards.Base
{
    public class CardInteract : MonoBehaviour, IInteractable
    {
        public GameObject GameObject => gameObject;
        [SerializeField] private GameObject hoverHighlight;
        [SerializeField] private GameObject selectedHighlight;

        private PlayerInteraction _playerInteraction;
        public PlayerInteraction PlayerInteraction
        {
            get => _playerInteraction;
            set => _playerInteraction = value;
        }

        
        private bool _selected;

        public bool Selected
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
                    return;
                }
                OnDeSelect();
            }
        }

        
        public void OnHover()
        {
            hoverHighlight.SetActive(true);
        }
        public void OnStopHover()
        {
            hoverHighlight.SetActive(false);
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
            OnStopHover();
            selectedHighlight.SetActive(true);
        }

        private void OnDeSelect()
        {
            selectedHighlight.SetActive(false);
        }

        public bool CheckForSelectedInteraction(IInteractable interactableObject)
        {
            if (interactableObject.GameObject.CompareTag("row")) return true;
            if (interactableObject.GameObject == gameObject) return true;
            return false;
        }


        public void Play()
        {
            
        }
    }
}
