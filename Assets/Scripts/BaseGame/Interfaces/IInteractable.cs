using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Events;

namespace BaseGame.Interfaces
{
    public interface IInteractable
    {
        GameObject GameObject { get; }
        void OnHover();
        void Interact();
        void OnStopHover();
        bool Selected { get; }
        bool CheckForSelectedInteraction(IInteractable interactableObject);
    }
}
