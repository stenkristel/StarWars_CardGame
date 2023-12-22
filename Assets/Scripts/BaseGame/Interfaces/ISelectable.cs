using UnityEngine;

namespace BaseGame.Interfaces
{
    public interface ISelectable
    {
        bool IsInteractableWith(GameObject gameObject);
        bool IsSelected { get; set; }
        void OnSelectChange();
        void SelectedInteractWith(GameObject gameObject);
    }
}
