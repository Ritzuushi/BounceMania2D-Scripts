using System;
using System.Collections.Generic;
using UnityEngine;

namespace RGUtils.Events
{
    [CreateAssetMenu(fileName = "BoolEvent", menuName = "RGUtils/Events/BoolEvent")]
    public class BoolEvent : Event
    {
        [SerializeField] private event Action<bool> _event;

        public void Invoke(bool arg) => _event?.Invoke(arg);

        public void AddListener(Action<bool> listener) => _event += listener;
        public void AddListener(params Action<bool>[] listeners)
        {
            foreach (var listener in listeners)
            {
                _event += listener;
            }
        }

        public void RemoveListener(Action<bool> listener) => _event -= listener;
        public void RemoveListener(params Action<bool>[] listeners)
        {
            foreach (var listener in listeners)
            {
                _event -= listener;
            }
        }
    }
}
