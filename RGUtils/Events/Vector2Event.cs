using System;
using System.Collections.Generic;
using UnityEngine;

namespace RGUtils.Events
{
    [CreateAssetMenu(fileName = "Vector2Event", menuName = "RGUtils/Events/Vector2Event")]
    public class Vector2Event : Event
    {
        [SerializeField] private event Action<Vector2> _event;

        public void Invoke(Vector2 arg) => _event?.Invoke(arg);

        public void AddListener(Action<Vector2> listener) => _event += listener;
        public void AddListener(params Action<Vector2>[] listeners)
        {
            foreach (var listener in listeners)
            {
                _event += listener;
            }
        }

        public void RemoveListener(Action<Vector2> listener) => _event -= listener;
        public void RemoveListener(params Action<Vector2>[] listeners)
        {
            foreach (var listener in listeners)
            {
                _event -= listener;
            }
        }
    }
}