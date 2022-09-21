using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RGames.TimerSystem
{
    public class TimerUi : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;

        [SerializeField] private TimerManager _timerManager;

        private void Awake()
        {
            UpdateTimer();
        }

        public void UpdateTimer()
        {
            _timerText.SetText(_timerManager.SecondsRemaining.ToString("0.0"));
        }
    }
}
