using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RGUtils.Events;

namespace RGames.PlayerSystem
{
    public class PlayerBounceUi : MonoBehaviour
    {
        [SerializeField] private PlayerBounceManager _playerBounceManager;

        [SerializeField] private TextMeshProUGUI _bounceCountText;

        [SerializeField] private SimpleEvent _playerBounced;

        [SerializeField] private SimpleEvent _playerScored;

        private void OnEnable()
        {
            _playerBounced.AddListener(UpdateBounceCount);
            _playerScored.AddListener(DeactivateBounceCount);
        }

        private void OnDisable()
        {
            _playerBounced.RemoveListener(UpdateBounceCount);
            _playerScored.RemoveListener(DeactivateBounceCount);
        }

        private void DeactivateBounceCount()
        {
            _bounceCountText.gameObject.SetActive(false);
        }

        private void UpdateBounceCount()
        {
            if (!_bounceCountText.gameObject.activeInHierarchy) _bounceCountText.gameObject.SetActive(true);
            _bounceCountText.SetText($"+{_playerBounceManager.BounceCount}");
        }
    }
}
