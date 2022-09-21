using System;
using System.Collections.Generic;
using UnityEngine;
using RGUtils.Events;
using MoreMountains.Feedbacks;

namespace RGames.PlayerSystem
{
    public class PlayerBounceManager : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;

        [SerializeField] private PlayerMoveManager _playerMoveManager;

        [SerializeField] private SimpleEvent _playerBounced;

        [SerializeField] private SimpleEvent _playerScored;

        [SerializeField] private Vector3Event _rotatePlayer;

        [SerializeField] private MMF_Player _bouncedFeedbacks;

        [field: SerializeField] public int BounceCount { get; private set; }

        private void OnEnable()
        {
            _playerScored.AddListener(ResetBounceCount);
        }

        private void OnDisable()
        {
            _playerScored.RemoveListener(ResetBounceCount);
        }

        private void ResetBounceCount()
        {
            BounceCount = 0;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("HorizontalWall"))
            {
                _rb.velocity = new Vector2(_playerMoveManager.CurrentVelocity.x, -_playerMoveManager.CurrentVelocity.y);
                _playerMoveManager.CurrentVelocity = _rb.velocity;
                _playerMoveManager.IsTouchingWall = true;
                _rotatePlayer.Invoke(-_rb.velocity);
                _bouncedFeedbacks.PlayFeedbacks();
            }
            else if (col.gameObject.CompareTag("VerticalWall"))
            {
                _rb.velocity = new Vector2(-_playerMoveManager.CurrentVelocity.x, _playerMoveManager.CurrentVelocity.y);
                _playerMoveManager.CurrentVelocity = _rb.velocity;
                _playerMoveManager.IsTouchingWall = true;
                _rotatePlayer.Invoke(-_rb.velocity);
                _bouncedFeedbacks.PlayFeedbacks();
            }
        }

        private void OnCollisionExit2D(Collision2D col)
        {
            BounceCount++;
            _playerBounced.Invoke();
            _playerMoveManager.IsTouchingWall = false;
        }
    }
}
