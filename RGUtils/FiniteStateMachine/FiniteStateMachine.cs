using System;
using System.Collections.Generic;
using UnityEngine;

namespace RGUtils.FSM
{
    public class FiniteStateMachine<T> : ScriptableObject where T : Enum
    {
        public T State;
    }
}
