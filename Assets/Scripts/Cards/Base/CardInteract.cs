using System;
using System.Collections.Generic;
using BaseGame.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Cards.Base
{
    public class CardInteract : MonoBehaviour, ISelectable
    {
        [SerializeField] private GameObject selectedHighlight;
        [SerializeField] private Vector3 selectedScaleChange;
        [SerializeField] private List<string> interactableGameObjects;
        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnSelectChange();
            }
        }

        public bool IsInteractableWith(GameObject gameObject)
        {
            foreach (var interactableObject in interactableGameObjects)
            {
                if (gameObject.CompareTag(interactableObject)) return true;
            }

            return false;
        }


        public void OnSelectChange()
        {
            selectedHighlight.SetActive(_isSelected);
            Vector3 scaleChange = _isSelected ? selectedScaleChange : -selectedScaleChange;
            ChangeObjectScale(scaleChange);
        }

        public void SelectedInteractWith(GameObject gameObject)
        {
            if (gameObject.CompareTag("row")) Play(gameObject.transform.position);
        }
        
        private void Play(Vector3 playPosition)
        {
            Vector3 position = gameObject.transform.position;
            var newPosition = playPosition;
            gameObject.transform.position = new Vector3(position.x, newPosition.y + 0.1f, newPosition.z);

        }

        private void ChangeObjectScale(Vector3 scaleChange)
        {
            gameObject.transform.localScale += scaleChange;
        }
    
    }
}
