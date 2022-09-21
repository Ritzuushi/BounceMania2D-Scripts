using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RGUtils.RVariables
{
    [Serializable]
    public class RString
    {
        [Space(5)][field: SerializeField] public string Value;

        [Space(5)] public UnityEvent<string> ValueChanged;

        public void Set(string newValue)
        {
            if (newValue == Value) return;
            Value = newValue;
            ValueChanged.Invoke(Value);
        }
    }
}
