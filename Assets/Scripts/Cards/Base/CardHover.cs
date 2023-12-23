using System.Collections;
using System.Collections.Generic;
using BaseGame.Interfaces;
using UnityEngine;
using UnityEngine.Events;

public class CardHover : MonoBehaviour, IHoverable
{
    [SerializeField] private UnityEvent onHover;
    [SerializeField] private UnityEvent onNotHover;
    private bool _isHovered;
    public bool IsHovered
    {
        get => _isHovered;
        set
        {
            switch (value)
            {
                case true:
                    OnHover();
                    break;
                case false:
                    OnStopHover();
                    break;
            }
            _isHovered = value;
        }
    }

    private void OnStopHover()
    {
        onNotHover.Invoke();
    }

    private void OnHover()
    {
        onHover.Invoke();
    }
}
