using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RGUtils.Events;

namespace RGames.ScoreSystem
{
    public class ScoreUi : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        [SerializeField] private ScoreManager _scoreManager;

        [SerializeField] private SimpleEvent _playerScored;


        private void OnEnable()
        {
            _playerScored.AddListener(UpdateScore);
        }

        private void OnDisable()
        {
            _playerScored.RemoveListener(UpdateScore);
        }

        private void UpdateScore()
        {
            _scoreText.SetText(_scoreManager.Score.ToString());
        }
    }
}
