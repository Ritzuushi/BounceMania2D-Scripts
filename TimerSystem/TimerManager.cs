using System;
using System.Collections;
using UnityEngine;
using RGUtils.State;
using RGUtils.Events;

namespace RGames.TimerSystem
{
    public class TimerManager : MonoBehaviour
    {

        [SerializeField] private TimerUi _timerUi;

        [SerializeField] private State _pausedState;

        [SerializeField] private SimpleEvent _playerLost;

        [SerializeField] private SimpleEvent _playerScored;

        [field: SerializeField] public float SecondsRemaining { get; private set; }

        private readonly WaitForSeconds _second = new WaitForSeconds(0.1f);

        private void Awake()
        {
            StartTimer();
        }

        private void OnEnable()
        {
            _pausedState.Entered += PausedStateEntered;
            _pausedState.Left += PausedStateLeft;
            _playerScored.AddListener(AddSeconds);
            _playerLost.AddListener(StopTimer);
        }

        private void OnDisable()
        {
            _pausedState.Entered -= PausedStateEntered;
            _pausedState.Left -= PausedStateLeft;
            _playerScored.RemoveListener(AddSeconds);
            _playerLost.RemoveListener(StopTimer);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AddSeconds();
            }
        }

        private void PausedStateEntered()
        {
            StopTimer();
        }

        private void PausedStateLeft()
        {
            StartTimer();
        }

        private void AddSeconds()
        {
            SecondsRemaining += 3;

            StopTimer();
            StartTimer();
        }

        private void StartTimer()
        {
            StartCoroutine("Timer");
        }

        private void StopTimer()
        {
            StopCoroutine("Timer");
        }

        private IEnumerator Timer()
        {
            while (true)
            {
                yield return _second;

                SecondsRemaining -= 0.1f;

                if (SecondsRemaining <= 0)
                {
                    Lose();
                    yield break;
                }

                _timerUi.UpdateTimer();
            }

        }

        private void Lose()
        {
            _playerLost.Invoke();
        }
    }
}
