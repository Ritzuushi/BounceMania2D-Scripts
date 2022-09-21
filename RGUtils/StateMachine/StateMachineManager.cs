using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RGUtils.State
{
    [DefaultExecutionOrder(-1)]
    public class StateMachineManager : MonoBehaviour
    {
        [SerializeField] private List<StateMachine> _stateMachines = new List<StateMachine>();

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            foreach (var stateMachine in _stateMachines)
            {
                stateMachine.StateMachineManager = this;
                stateMachine.Initialize();
            }
        }

        private void OnDisable()
        {
            foreach (var stateMachine in _stateMachines)
            {
                stateMachine.Deactivate();
            }
        }
    }
}
