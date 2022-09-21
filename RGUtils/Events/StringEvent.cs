using System;
using System.Collections.Generic;
using UnityEngine;

namespace RGUtils.Events
{
    [CreateAssetMenu(fileName = "StringEvent", menuName = "RGUtils/Events/StringEvent")]
    public class StringEvent : Event
    {
        [SerializeField] private event Action<string> _event;

        public void Invoke(string arg) => _event?.Invoke(arg);

        public void AddListener(Action<string> listener) => _event += listener;
        public void AddListener(params Action<string>[] listeners)
        {
            foreach (var listener in listeners)
            {
                _event += listener;
            }
        }

        public void RemoveListener(Action<string> listener) => _event -= listener;
        public void RemoveListener(params Action<string>[] listeners)
        {
            foreach (var listener in listeners)
            {
                _event -= listener;
            }
        }
    }
}