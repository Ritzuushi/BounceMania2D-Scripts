using System;
using System.Collections.Generic;
using UnityEngine;
using RGUtils.State;
using RGUtils.Events;
using MoreMountains.Feedbacks;

namespace RGames.PlayerSystem
{
    public class PlayerLoseManager : MonoBehaviour
    {
        [SerializeField] private MMF_Player _loseFeedbacks;
        [SerializeField] private SimpleEvent _playerLost;
        [SerializeField] private StateMachine _gameSM;
        [SerializeField] private GameObject _gameCanvas;

        private void OnEnable()
        {
            _playerLost.AddListener(Lose);
        }

        private void OnDisable()
        {
            _playerLost.RemoveListener(Lose);
        }

        private void Lose()
        {
            _loseFeedbacks.PlayFeedbacks();
            _gameCanvas.SetActive(false);
            _gameSM.SetState("Over");
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Obstacle"))
            {
                _playerLost.Invoke();
            }
        }
    }
}
