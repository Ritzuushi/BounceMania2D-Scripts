using System;
using System.Collections.Generic;
using UnityEngine;
using RGUtils.Events;

namespace RGames.PlayerSystem
{
    public class PlayerRotationManager : MonoBehaviour
    {
        [SerializeField] private Transform _playerSprite;
        [SerializeField] private Vector3Event _rotatePlayer;
        //[SerializeField] private PlayerMoveManager _playerMoveManager;

        private void OnEnable()
        {
            _rotatePlayer.AddListener(Rotate);
        }

        private void OnDisable()
        {
            _rotatePlayer.RemoveListener(Rotate);
        }

        private void Rotate(Vector3 value)
        {
            _playerSprite.up = -value;
        }
    }
}
