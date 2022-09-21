using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RGUtils.RVariables
{
    [Serializable]
    public class RInt
    {
        [Space(5)][field: SerializeField] public int Value;

        [Space(5)] public UnityEvent<int> ValueChanged;

        [Space(5)] public UnityEvent<string> ValueChangedToString;

        public void Set(int newValue)
        {
            if (newValue == Value) return;
            Value = newValue;
            ValueChanged.Invoke(Value);
            ValueChangedToString.Invoke(Value.ToString());
        }
    }
}
