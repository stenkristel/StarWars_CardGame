using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Serializable]
    public struct KeyBinding
    {
        public KeyCode keyCode;
        public BaseCommand command;
    }

    [SerializeField] private List<KeyBinding> bindings;

    private void Update()
    {
        DetectInput();
    }

    private void DetectInput()
    {
        if (!Input.anyKey) return;
        for (int i = 0; i < bindings.Count; i++)
        {
            var keyBinding = bindings.ElementAt(i);
            if (Input.GetKeyDown(keyBinding.keyCode))
            {
                BaseCommand command = keyBinding.command;
                command.Execute();
            }
        }
    }
}
