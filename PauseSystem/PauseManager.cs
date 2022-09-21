using System;
using System.Collections.Generic;
using UnityEngine;
using RGUtils.State;

namespace RGames.PauseSystem
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private GameObject _noPostCamera;

        [SerializeField] private GameObject _pauseBtn;

        [SerializeField] private State _pausedState;

        private void OnEnable()
        {
            _pausedState.Entered += EnteredPausedState;
            _pausedState.Left += LeftPausedState;
        }

        private void OnDisable()
        {
            _pausedState.Entered -= EnteredPausedState;
            _pausedState.Left -= LeftPausedState;
        }

        private void EnteredPausedState()
        {
            _noPostCamera.SetActive(true);
            Time.timeScale = 0;
            _pauseBtn.SetActive(false);
        }

        private void LeftPausedState()
        {
            _noPostCamera.SetActive(false);
            Time.timeScale = 1;
            _pauseBtn.SetActive(true);
        }
    }
}
