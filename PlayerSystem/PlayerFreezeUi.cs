using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RGUtils.Events;

namespace RGames.PlayerSystem
{
    public class PlayerFreezeUi : MonoBehaviour
    {
        [SerializeField] private PlayerFreezeManager _playerFreezeManager;

        [SerializeField] private TextMeshProUGUI _freezeCountText;

        [SerializeField] private SimpleEvent _playerStopped;

        [SerializeField] private SimpleEvent _playerShot;

        private void OnEnable()
        {
            _playerShot.AddListener(HideFreezeCount);
            _playerStopped.AddListener(ShowFreezeCount);
            _playerFreezeManager.FreezeCountChanged += UpdateFreezeCount;
        }

        private void OnDisable()
        {
            _playerShot.RemoveListener(HideFreezeCount);
            _playerStopped.RemoveListener(ShowFreezeCount);
            _playerFreezeManager.FreezeCountChanged -= UpdateFreezeCount;
        }

        private void ShowFreezeCount()
        {
            _freezeCountText.gameObject.SetActive(true);
        }

        private void HideFreezeCount()
        {
            _freezeCountText.gameObject.SetActive(false);
        }

        private void UpdateFreezeCount()
        {
            _freezeCountText.SetText(_playerFreezeManager.FreezeCount.ToString());
        }
    }
}
