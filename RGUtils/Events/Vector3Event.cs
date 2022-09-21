using System;
using System.Collections.Generic;
using UnityEngine;

namespace RGUtils.Events
{
    [CreateAssetMenu(fileName = "Vector3Event", menuName = "RGUtils/Events/Vector3Event")]
    public class Vector3Event : Event
    {
        [SerializeField] private event Action<Vector3> _event;

        public void Invoke(Vector3 arg) => _event?.Invoke(arg);

        public void AddListener(Action<Vector3> listener) => _event += listener;
        public void AddListener(params Action<Vector3>[] listeners)
        {
            foreach (var listener in listeners)
            {
                _event += listener;
            }
        }

        public void RemoveListener(Action<Vector3> listener) => _event -= listener;
        public void RemoveListener(params Action<Vector3>[] listeners)
        {
            foreach (var listener in listeners)
            {
                _event -= listener;
            }
        }
    }
}
