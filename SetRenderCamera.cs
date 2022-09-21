using System;
using System.Collections.Generic;
using UnityEngine;

namespace RGames
{
    public class SetRenderCamera : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _canvas.worldCamera = Camera.main;
        }
    }
}
