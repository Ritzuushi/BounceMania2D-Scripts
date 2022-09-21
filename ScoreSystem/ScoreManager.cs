using System;
using System.Collections.Generic;
using UnityEngine;
using RGUtils.Events;

namespace RGames.ScoreSystem
{
    public class ScoreManager : MonoBehaviour
    {
        [field: SerializeField] public int Score { get; private set; }

        [SerializeField] private IntEvent _playerScored;

        private void OnEnable()
        {
            _playerScored.AddListener(AddScore);
        }

        private void OnDisable()
        {
            _playerScored.RemoveListener(AddScore);
        }

        private void AddScore(int bounceCount)
        {
            Score += 1 + bounceCount;
        }
    }
}
