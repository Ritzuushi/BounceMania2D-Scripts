using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RGUtils.Events
{
    [CreateAssetMenu(fileName = "SimpleEvent", menuName = "RGUtils/Events/SimpleEvent")]
    public class SimpleEvent : Event
    {
        [SerializeField] private event Action _event;

        public void Invoke() => _event?.Invoke();

        public void AddListener(Action listener) => _event += listener;
        public void AddListener(params Action[] listeners)
        {
            foreach (var listener in listeners)
            {
                _event += listener;
            }
        }

        public void RemoveListener(Action listener) => _event -= listener;
        public void RemoveListener(params Action[] listeners)
        {
            foreach (var listener in listeners)
            {
                _event -= listener;
            }
        }
    }
}
