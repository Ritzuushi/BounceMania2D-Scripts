using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RGUtils.RVariables
{
    [Serializable]
    public class RBool
    {
        [Space(5)][field: SerializeField] public bool Value;

        [Space(5)] public UnityEvent<bool> ValueChanged;

        [Space(5)] public UnityEvent<string> ValueChangedToString;

        public void Set(bool newValue)
        {
            if (newValue == Value) return;
            Value = newValue;
            ValueChanged.Invoke(Value);
            ValueChangedToString.Invoke(Value.ToString());
        }
    }
}
