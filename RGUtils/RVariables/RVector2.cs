using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RGUtils.RVariables
{
    [Serializable]
    public class RVector2
    {
        [Space(5)][field: SerializeField] public Vector2 Value;

        [Space(5)] public UnityEvent<Vector2> ValueChanged;

        [Space(5)] public UnityEvent<string> ValueChangedToString;

        public void Set(Vector2 newValue)
        {
            if (newValue == Value) return;
            Value = newValue;
            ValueChanged.Invoke(Value);
            ValueChangedToString.Invoke(Value.ToString());
        }
    }
}
