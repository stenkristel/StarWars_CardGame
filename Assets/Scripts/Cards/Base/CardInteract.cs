using System.Collections.Generic;
using BaseGame.Interfaces;
using Player;
using Unity.VisualScripting;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.Serialization;

namespace Cards.Base
{
    public class CardInteract : MonoBehaviour, IInteractable
    {
        public GameObject GameObject => gameObject;
        public bool IsOnlySelectableByObject => false;
        [SerializeField] private GameObject hoverHighlight;
        [SerializeField] private GameObject selectedHighlight;
        private PlayerInteraction _playerInteraction;
        
        [SerializeField] private bool isSelected;
        [SerializeField] private float scaleChange;

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
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
                IsSelected = !IsSelected;
            }
        }
        private void OnSelected()
        {
            OnStopHover();
            selectedHighlight.SetActive(true);
            ChangeObjectScale(scaleChange);
        }

        private void OnDeSelect()
        {
            selectedHighlight.SetActive(false);
            ChangeObjectScale(-scaleChange);
        }

        public bool CheckForSelectedInteraction(IInteractable interactableObject)
        {
            if (interactableObject.GameObject.CompareTag("row")) return true;
            if (interactableObject.GameObject == gameObject) return true;
            return false;
        }
        
        public void OnSelectedInteract(IInteractable interactedObject)
        {
            Play(interactedObject.GameObject.transform.position);
            IsSelected = false;
            interactedObject.IsSelected = false;
        }

        private void ChangeObjectScale(float scaleChange)
        {
            gameObject.transform.localScale += new Vector3(scaleChange, 0, scaleChange);
        }
        public void Play(Vector3 playPosition)
        {
            Vector3 position = gameObject.transform.position;
            var newPosition = playPosition;
            gameObject.transform.position = new Vector3(position.x, newPosition.y + 0.1f, newPosition.z);
            
        }
    }
}
