using System;
using BaseGame.Interfaces;
using UnityEngine;

namespace BaseGame
{
    public class HoverChecker : MonoBehaviour
    { 
        private IHoverable _hoverable;
        public GameObject HoveredGameObject { get; set; }

        private void Update()
        {
            HoveredGameObject = CheckForHover();
        }

        private GameObject CheckForHover()
        {
            Ray screenToCursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(screenToCursorRay, out var hitInfo)) return null;
            
            var hitObject = hitInfo.collider.gameObject;
            if (hitObject == HoveredGameObject) return hitObject;

            CheckIfHoverable(hitObject);
            return hitObject;
        }

        private void CheckIfHoverable(GameObject hoveredObject)
        {
            var hoverable = hoveredObject.GetComponent<IHoverable>();
            if (hoverable == _hoverable) return;
            if(_hoverable != null)
            {
                _hoverable.IsHovered = false;
            }
            _hoverable = hoverable;
            if (_hoverable != null) _hoverable.IsHovered = true;
        }
    }
}
