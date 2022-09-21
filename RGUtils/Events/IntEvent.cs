using System;
using System.Collections.Generic;
using UnityEngine;

namespace RGUtils.Events
{
    [CreateAssetMenu(fileName = "IntEvent", menuName = "RGUtils/Events/IntEvent")]
    public class IntEvent : Event
    {
        [SerializeField] private event Action<int> _event;

        public void Invoke(int arg) => _event?.Invoke(arg);

        public void AddListener(Action<int> listener) => _event += listener;
        public void AddListener(params Action<int>[] listeners)
        {
            foreach (var listener in listeners)
            {
                _event += listener;
            }
        }

        public void RemoveListener(Action<int> listener) => _event -= listener;
        public void RemoveListener(params Action<int>[] listeners)
        {
            foreach (var listener in listeners)
            {
                _event -= listener;
            }
        }
    }
}
