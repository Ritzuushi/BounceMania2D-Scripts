using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RGUtils.State
{
    [DefaultExecutionOrder(-1)]
    public class StateManager : MonoBehaviour
    {
        [SerializeField] private List<State> _states = new List<State>();

        private void Awake()
        {
            foreach (var state in _states)
            {
                state.Active = false;
            }

            DontDestroyOnLoad(gameObject);
        }
    }
}
