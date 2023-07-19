using BaseGame.Interfaces;
using UnityEngine;

namespace Cards.Base
{
    public class CardInteract : MonoBehaviour, IInteractable
    {
        public void OnHover()
        {
            
        }

        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) Debug.Log("Interact with " + gameObject.name);
        }
    }
}
