using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RGUtils.Events
{
    [CreateAssetMenu(fileName = "ComplexEvent", menuName = "RGUtils/Events/ComplexEvent")]
    public class ComplexEvent : Event
    {
        [SerializeField] private event Action<Dictionary<string, object>> _event;

        public void Invoke(Dictionary<string, object> args = null) => _event?.Invoke(args);

        public void AddListener(Action<Dictionary<string, object>> listener) => _event += listener;
        public void AddListener(params Action<Dictionary<string, object>>[] listeners)
        {
            foreach (var listener in listeners)
            {
                _event += listener;
            }
        }

        public void RemoveListener(Action<Dictionary<string, object>> listener) => _event -= listener;
        public void RemoveListener(params Action<Dictionary<string, object>>[] listeners)
        {
            foreach (var listener in listeners)
            {
                _event -= listener;
            }
        }
    }
}
