using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RGUtils.Events
{
    [DefaultExecutionOrder(-1)]
    public class EventManager : MonoBehaviour
    {
        [SerializeField] private List<Event> _events;

        private void Awake()
        {
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            var locations = Addressables.LoadResourceLocationsAsync("Event", typeof(Event)).WaitForCompletion();

            foreach (var location in locations)
            {
                _events.Add(Addressables.LoadAssetAsync<Event>(location).WaitForCompletion());
            }
        }
    }
}
