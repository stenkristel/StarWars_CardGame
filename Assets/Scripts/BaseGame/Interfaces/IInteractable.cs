using System.Collections.Generic;
using Player;
using UnityEngine;

namespace BaseGame.Interfaces
{
    public interface IInteractable
    {
        GameObject GameObject { get; }
        void OnHover();
        void Interact();
        bool Selectable { get; }
        PlayerInteraction PlayerInteraction { get; set; }
    }
}
