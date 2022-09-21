using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RGUtils.State;
using RGUtils.Events;
using RGames.PlayerSystem;
using DG.Tweening;

namespace RGames.SlingshotSystem
{
    public class SlingshotManager : MonoBehaviour
    {
        private Touch _touch;

        [SerializeField] private Camera _camera;

        private Vector2 _dragEndPos;
        private Vector2 _dragMovePos;
        private Vector2 _dragBeginPos;

        private Vector2 _force;
        private Vector2 _clampedForce;

        private bool _canShoot => _clampedForce.sqrMagnitude >= 100;

        private float _maxPower => _power * _power;

        [SerializeField] private float _power;
        [SerializeField] private float _maxForce;

        [SerializeField] private Image _meter;

        [SerializeField] private Image _aimArrow;

        [SerializeField] private State _overState;

        [SerializeField] private State _pausedState;

        [SerializeField] private Vector2Event _movePlayer;

        [SerializeField] private Vector3Event _rotatePlayer;

        [SerializeField] private PlayerMoveManager _playerMoveManager;

        private void Update()
        {
            Drag();
        }

        private void Reset()
        {
            _dragEndPos = _dragMovePos = _dragBeginPos = _force = _clampedForce = Vector2.zero;
            _aimArrow.gameObject.SetActive(false);
            _meter.fillAmount = 0;
        }

        private void Drag()
        {
            if (Input.touchCount == 0) return;
            if (_pausedState.Active) return;
            if (_overState.Active) return;

            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Began && _playerMoveManager.IsIdle) DragBegin();
            if (_touch.phase == TouchPhase.Moved && _playerMoveManager.IsIdle) DragMove();
            if (_touch.phase == TouchPhase.Ended && _playerMoveManager.IsIdle) DragEnd();
        }

        private void DragBegin()
        {
            _dragBeginPos = _camera.ScreenToWorldPoint(_touch.position);
        }

        private void DragMove()
        {
            _dragMovePos = _camera.ScreenToWorldPoint(_touch.position);

            _force = _dragBeginPos - _dragMovePos;
            _clampedForce = Vector2.ClampMagnitude(_force, _maxForce) * _power;

            _meter.fillAmount = _clampedForce.sqrMagnitude / 2000;

            _rotatePlayer.Invoke(_dragMovePos - _dragBeginPos);

            _aimArrow.gameObject.SetActive(true);
        }

        private void DragEnd()
        {
            if (!_canShoot) return;

            _dragEndPos = _camera.ScreenToWorldPoint(_touch.position);

            _force = _dragBeginPos - _dragEndPos;
            _clampedForce = Vector2.ClampMagnitude(_force, _maxForce) * _power;

            _movePlayer.Invoke(_clampedForce);

            Reset();
        }
    }
}
