using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace RGUtils.State
{
    [CreateAssetMenu(fileName = "StateMachine", menuName = "RGUtils/State/StateMachine")]
    public class StateMachine : ScriptableObject
    {
        [SerializeField] private State[] _states;

        [SerializeField] private State _initialState;

        private Dictionary<string, State> _stateDictionary;

        [field: SerializeField] public State NewState { get; private set; }

        [field: SerializeField] public State CurrentState { get; private set; }

        [field: SerializeField] public State PreviousState { get; private set; }

        public event Action CurrentStateChanged;

        public event Action CurrentStateTriggered;

        public StateMachineManager StateMachineManager;

        public void Initialize()
        {
            SetState(_initialState.name);
        }

        public void Deactivate()
        {
            NewState = null;
            CurrentState = null;
            PreviousState = null;
            StateMachineManager = null;
        }

        public void SetState(string stateName)
        {
            _stateDictionary ??= InitializeDictionary();

            if (_stateDictionary.TryGetValue(stateName, out State state))
            {
                NewState = state;
                PreviousState = CurrentState;
                if (CurrentState == null) { CurrentState = state; }
                else if (state == CurrentState) { CurrentStateTriggered?.Invoke(); return; }
                if (PreviousState != null) CurrentState.Leave();
                CurrentState = state;
                CurrentStateChanged?.Invoke();
                CurrentState.Enter();
                StateMachineManager.StartCoroutine(CurrentState.Stay());
            }
            else
            {
                Debug.LogWarning($"State {stateName} does not exist.");
            }
        }

        public bool IsCurrentState(string stateName)
        {
            _stateDictionary ??= InitializeDictionary();

            if (_stateDictionary.TryGetValue(stateName, out State state))
            {
                return state == CurrentState ? true : false;
            }
            else
            {
                Debug.Log($"State {stateName} does not exist.");
                return false;
            }
        }

        public State GetState(string stateName)
        {
            _stateDictionary ??= InitializeDictionary();

            return _stateDictionary.TryGetValue(stateName, out State state) ? state : null;
        }

        private Dictionary<string, State> InitializeDictionary() => _stateDictionary = _states.ToDictionary(state => state.name);
    }
}
