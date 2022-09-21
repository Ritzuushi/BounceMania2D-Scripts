using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RGUtils.RVariables
{
    [Serializable]
    public class RFloat
    {
        [Space(5)][field: SerializeField] public float Value;

        [Space(5)] public UnityEvent<float> ValueChanged;

        [Space(5)] public UnityEvent<string> ValueChangedToString;

        public void Set(float newValue)
        {
            if (newValue == Value) return;
            Value = newValue;
            ValueChanged.Invoke(Value);
            ValueChangedToString.Invoke(Value.ToString());
        }
    }
}
