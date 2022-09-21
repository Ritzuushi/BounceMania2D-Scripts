using System;
using System.Collections.Generic;
using UnityEngine;

namespace RGUtils.Events
{
    [CreateAssetMenu(fileName = "FloatEvent", menuName = "RGUtils/Events/FloatEvent")]
    public class FloatEvent : Event
    {
        [SerializeField] private event Action<float> _event;

        public void Invoke(float arg) => _event?.Invoke(arg);

        public void AddListener(Action<float> listener) => _event += listener;
        public void AddListener(params Action<float>[] listeners)
        {
            foreach (var listener in listeners)
            {
                _event += listener;
            }
        }

        public void RemoveListener(Action<float> listener) => _event -= listener;
        public void RemoveListener(params Action<float>[] listeners)
        {
            foreach (var listener in listeners)
            {
                _event -= listener;
            }
        }
    }
}