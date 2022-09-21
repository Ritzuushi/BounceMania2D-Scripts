using System;
using System.Collections.Generic;
using UnityEngine;
using RGUtils.Events;
using MoreMountains.Feedbacks;

namespace RGames.PlayerSystem
{
    public class PlayerScoreManager : MonoBehaviour
    {
        [SerializeField] private PlayerBounceManager _playerBounceManager;

        [SerializeField] private IntEvent _playerScoredInt;
        [SerializeField] private SimpleEvent _playerScored;

        [SerializeField] private MMF_Player _playerScoredFeedbacks;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Goal"))
            {
                _playerScoredInt.Invoke(_playerBounceManager.BounceCount);
                _playerScoredFeedbacks.PlayFeedbacks();
                _playerScored.Invoke();
            }
        }
    }
}
