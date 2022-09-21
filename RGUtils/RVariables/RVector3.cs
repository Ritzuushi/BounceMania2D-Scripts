using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RGUtils.RVariables
{
    [Serializable]
    public class RVector3
    {
        [Space(5)][field: SerializeField] public Vector3 Value;

        [Space(5)] public UnityEvent<Vector3> ValueChanged;

        [Space(5)] public UnityEvent<string> ValueChangedToString;

        public void Set(Vector3 newValue)
        {
            if (newValue == Value) return;
            Value = newValue;
            ValueChanged.Invoke(Value);
            ValueChangedToString.Invoke(Value.ToString());
        }
    }
}
