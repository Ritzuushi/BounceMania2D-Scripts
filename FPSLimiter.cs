using System;
using System.Collections.Generic;
using UnityEngine;

namespace RGames
{
    public class FPSLimiter : MonoBehaviour
    {
        [SerializeField] private int _targetFps;

        private void Awake()
        {
            Application.targetFrameRate = _targetFps;
        }
    }
}
