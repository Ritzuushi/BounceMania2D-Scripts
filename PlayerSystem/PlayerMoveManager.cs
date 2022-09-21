using System;
using System.Collections.Generic;
using UnityEngine;
using RGUtils.Events;

namespace RGames.PlayerSystem
{
    public class PlayerMoveManager : MonoBehaviour
    {
        public Vector2 CurrentVelocity;

        public bool IsTouchingWall;
        public bool IsIdle => _rb.velocity == Vector2.zero;

        [SerializeField] private Rigidbody2D _rb;

        [SerializeField] private Vector2Event _movePlayer;

        [SerializeField] private SimpleEvent _playerScored;

        [SerializeField] private SimpleEvent _playerShot;

        [SerializeField] private SimpleEvent _playerStopped;

        private void OnEnable()
        {
            _movePlayer.AddListener(MovePlayer);
            _playerScored.AddListener(StopPlayer);
        }

        private void OnDisable()
        {
            _movePlayer.RemoveListener(MovePlayer);
            _playerScored.RemoveListener(StopPlayer);
        }

        private void MovePlayer(Vector2 force)
        {
            _rb.velocity = force;
            CurrentVelocity = force;
            _playerShot.Invoke();
        }

        public void StopPlayer()
        {
            _rb.velocity = Vector2.zero;
            CurrentVelocity = Vector2.zero;
            _playerStopped.Invoke();
        }
    }
}
